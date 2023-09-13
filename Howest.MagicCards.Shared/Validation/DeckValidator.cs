using FluentValidation;
using Howest.MagicCards.DAL.Repositories;
using Howest.MagicCards.DAL.Models;

namespace Howest.MagicCards.Shared.Validation
{
    public class DeckValidator : AbstractValidator<DeckRepository>
    {
        public DeckValidator()
        {   
            RuleFor(deck => deck.Id).NotNull();
            RuleFor(deck => deck.Name).NotEmpty().Length(1, 150);
            RuleFor(deck => deck.Cards).Must(ValidateCards).WithMessage("Invalid card(s) found in deck.");
        }
        private bool ValidateCards(List<CardDeck> cards)
        {
            DeckCardValidator validator = new();
            foreach (CardDeck card in cards)
            {
                if (!validator.Validate(card).IsValid)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
