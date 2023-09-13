using Howest.MagicCards.DAL.Models;
using Howest.MagicCards.Shared.Filters;

namespace Howest.MagicCards.Shared.ExtensionMethods
{
    public static class CardFilterExtensions
    {
        public static IQueryable<Card> ApplyFilters(this IQueryable<Card> cards, CardFilterParameters filterParams)
        {
            if (filterParams.Name != null)
            {
                cards = cards.Where(card => card.Name.Contains(filterParams.Name));
            }
            if (filterParams.Text != null)
            {
                cards = cards.Where(card => card.Text.Contains(filterParams.Text));
            }
            if (filterParams.Artist != null)
            {
                cards = cards.Where(card => card.Artist.FullName.Contains(filterParams.Artist));
            }
            if (filterParams.Type != null)
            {
                cards = cards.Where(card => card.Type.Contains(filterParams.Type));
            }
            if (filterParams.Rarity != null)
            {
                cards = cards.Where(card => card.RarityCodeNavigation.Name.Equals(filterParams.Rarity));
            }
            if (filterParams.Set != null)
            {
                cards = cards.Where(card => card.SetCodeNavigation.Name.Contains(filterParams.Set));
            }

            return cards;
        }

        public static IQueryable<Card> ApplyFiltersV1_1(this IQueryable<Card> cards, CardFilterParametersV1_1 filterParams)
        {
            if (filterParams.Name != null)
            {
                cards = cards.Where(card => card.Name.Contains(filterParams.Name));
            }
            if (filterParams.Text != null)
            {
                cards = cards.Where(card => card.Text.Contains(filterParams.Text));
            }
            if (filterParams.Artist != null)
            {
                cards = cards.Where(card => card.Artist.FullName.Contains(filterParams.Artist));
            }
            if (filterParams.Type != null)
            {
                cards = cards.Where(card => card.Type.Contains(filterParams.Type));
            }
            if (filterParams.Rarity != null)
            {
                cards = cards.Where(card => card.RarityCodeNavigation.Name.Equals(filterParams.Rarity));
            }
            if (filterParams.Set != null)
            {
                cards = cards.Where(card => card.SetCodeNavigation.Name.Contains(filterParams.Set));
            }

            return cards;
        }
    }
}
