using FluentValidation;
using Howest.MagicCards.DAL.Models;
using Howest.MagicCards.Shared.DTO;

namespace Howest.MagicCards.Shared.Validation
{
    public class DeckCardValidator : AbstractValidator<CardDeck>
    {
        public DeckCardValidator()
        {
            RuleFor(card => card.Id).NotNull();
            RuleFor(card => card.Name).NotEmpty();
        }
    }
}
