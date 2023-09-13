using Howest.MagicCards.DAL.Models;
using Howest.MagicCards.DAL.Repositories;
using Howest.MagicCards.Shared.Response;
using Howest.MagicCards.Web.Service;
using Microsoft.AspNetCore.Components;

namespace Howest.MagicCards.Web.Pages
{
    public partial class Deck
    {
        [Inject]
        private CardService cardService { get; set; }

        public List<DeckRepository> AllDecks { get; set; } = new List<DeckRepository>();
        public List<CardDeck> DeckCards { get; set; } = new List<CardDeck>();

        public long _currentDeck = -1;
        public string _deckName = "Deck Name";


        protected override async Task OnInitializedAsync()
        {
            WebApiClient.BaseAddress = new Uri("https://localhost:7103/");
            MinimalApiClient.BaseAddress = new Uri("https://localhost:7061/");
            await LoadDecks();
        }

        public void AddToDeck(long id, string name, string manacost)
        {
            if (DeckCards.Count < 60)
            {
                CardDeck newCard = new(id, name, manacost);
                DeckCards.Add(newCard);
                StateHasChanged();
            }
        }

        private void RemoveFromDeck(long id)
        {
            CardDeck cardToRemove = DeckCards.FirstOrDefault(c => c.Id == id);
            if (cardToRemove != null)
            {
                DeckCards.Remove(cardToRemove);
            }
            StateHasChanged();
        }

        private void ClearDeck()
        {
            DeckCards.Clear();
        }

        private async Task SubmitDeck()
        {
            if (DeckCards != null && DeckCards.Count != 0)
            {
                if (_currentDeck == -1)
                {
                    await CreateNewDeck();
                }
                else
                {
                    await UpdateExistingDeck();
                }
            }
        }

        private async Task CreateNewDeck()
        {
            DeckRepository deckRepo = new(0, _deckName, DeckCards);
            HttpResponseMessage response = await MinimalApiClient.PostAsJsonAsync(cardService._minimalDeckBaseUri, deckRepo);
            await LoadDecks();
            ResetDeck();
        }

        private async Task UpdateExistingDeck()
        {
            DeckRepository deckRepo = new(_currentDeck, _deckName, DeckCards);
            HttpResponseMessage response = await MinimalApiClient.PutAsJsonAsync(cardService._minimalDeckBaseUri + _currentDeck, deckRepo);
            await LoadDecks();
            ResetDeck();
        }

        private async Task DeleteDeck()
        {
            DeckRepository deckRepo = new DeckRepository(_currentDeck, _deckName, DeckCards);
            if (_currentDeck != -1)
            {
                await MinimalApiClient.DeleteAsync(cardService._minimalDeckBaseUri + _currentDeck);
                await LoadDecks();
                ResetDeck();
            }
        }

        private async Task LoadDecks()
        {
            try
            {
                DeckResponse<List<DeckRepository>> response = await WebApiClient.GetFromJsonAsync<DeckResponse<List<DeckRepository>>>(cardService._deckBaseUri);
                AllDecks = response.Deck;
            }
            catch (HttpRequestException)
            {
                AllDecks = new List<DeckRepository>();
            }
        }

        private async Task LoadDeck()
        {
            ClearDeck();
            if (_currentDeck != -1)
            {
                DeckResponse<DeckRepository> response = await WebApiClient.GetFromJsonAsync<DeckResponse<DeckRepository>>(cardService._deckBaseUri + _currentDeck);
                DeckRepository deck = response.Deck;
                _deckName = deck.Name;
                foreach (CardDeck card in deck.Cards)
                {
                    AddToDeck(card.Id, card.Name, card.ManaCost);
                }
            }
            else
            {
                _deckName = "Deck Name";
            }
        }

        private async Task HandleDeckChange(ChangeEventArgs e)
        {
            int selectedDeckId = Convert.ToInt32(e.Value);
            _currentDeck = selectedDeckId;
            await LoadDeck();
        }

        private void ResetDeck()
        {
            ClearDeck();
            _currentDeck = -1;
            _deckName = "Deck Name";
        }
    }
}