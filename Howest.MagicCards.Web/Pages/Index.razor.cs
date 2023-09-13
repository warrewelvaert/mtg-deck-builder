using Howest.MagicCards.Shared.DTO;
using Howest.MagicCards.Shared.Response;
using Howest.MagicCards.Web.Service;
using Microsoft.AspNetCore.Components;
using System.Collections.Specialized;

namespace Howest.MagicCards.Web.Pages
{
    public partial class Index
    {
        [Inject]
        private CardService cardService { get; set; }

        public IEnumerable<CardReadDTO> _allCards;

        private CardDetailReadDTO DetailedCard { get; set; }

        private Deck _deckComponent;

        private string _nameFilter, _textFilter, _artistFilter, _typeFilter, _setFilter, _rarityFilter = "";
        private string _orderFilter = "asc";
        private int _pageSize = 150;
        private int _currentPage = 1;
        private string _isDetailVisible = "hidden";

        protected override async Task OnInitializedAsync()
        {
            WebApiClient.BaseAddress = new Uri("https://localhost:7103/");
            MinimalApiClient.BaseAddress = new Uri("https://localhost:7061/");
            await GetCardsAsync();
        }

        public async Task GetCardsAsync()
        {
            UriBuilder uriBuilder = new($"https://localhost:7103/api/Card/{cardService._apiVersion}" );

            AddQueryParameter(ref uriBuilder, "Name", _nameFilter);
            AddQueryParameter(ref uriBuilder, "Text", _textFilter);
            AddQueryParameter(ref uriBuilder, "Set", _setFilter);
            AddQueryParameter(ref uriBuilder, "Type", _typeFilter);
            AddQueryParameter(ref uriBuilder, "Rarity", _rarityFilter);
            AddQueryParameter(ref uriBuilder, "Artist", _artistFilter);
            AddQueryParameter(ref uriBuilder, "SortOrder", _orderFilter);
            AddQueryParameterForInt(ref uriBuilder, "PageNumber", _currentPage);
            AddQueryParameterForInt(ref uriBuilder, "PageSize", _pageSize);
            try
            {
                MagicCardsResponse response = await WebApiClient.GetFromJsonAsync<MagicCardsResponse>(uriBuilder.Uri.PathAndQuery);
                _allCards = response.Cards;
            }
            catch (HttpRequestException)
            {
                _allCards = new List<CardReadDTO>();
            }

        }

        private static void AddQueryParameter(ref UriBuilder uriBuilder, string key, string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                NameValueCollection query = System.Web.HttpUtility.ParseQueryString(uriBuilder.Query);
                query[key] = value;
                uriBuilder.Query = query.ToString();
            }
        }

        private static void AddQueryParameterForInt(ref UriBuilder uriBuilder, string key, int value)
        {
            if (value > 0)
            {
                NameValueCollection query = System.Web.HttpUtility.ParseQueryString(uriBuilder.Query);
                query[key] = value.ToString();
                uriBuilder.Query = query.ToString();
            }
        }

        public async Task LoadCardDetail(long id)
        {
            CardDetailResponse response = await WebApiClient.GetFromJsonAsync<CardDetailResponse>($"api/Card/{cardService._apiVersion}/{id}");
            DetailedCard = response.CardDetail;
            ToggleDetailScreen();
        }

        private void ToggleDetailScreen()
        {
            if (_isDetailVisible != "hidden")
            {
                _isDetailVisible = "hidden";
            }
            else
            {
                _isDetailVisible = "";
            }
        }

        private void AddToDeck(long id, string name, string manacost)
        {
            _deckComponent.AddToDeck(id, name, manacost);
            _isDetailVisible = "hidden";
            StateHasChanged();
        }
    }
}
