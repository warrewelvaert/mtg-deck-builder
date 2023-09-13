using Howest.MagicCards.DAL.Models;
using Howest.MagicCards.Shared.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Howest.MagicCards.Shared.ExtensionMethods
{
    public static class CardOrderExtension
    {
        public static IQueryable<Card> ApplyOrder(this IQueryable<Card> cards, CardFilterParameters filterParams)
        {
            if (!(string.IsNullOrEmpty(filterParams.SortOrder)) && filterParams.SortOrder.ToLower() == "desc")
            {
                return cards.OrderByDescending(card => card.Name);
            }
            else if (!(string.IsNullOrEmpty(filterParams.SortOrder)) && filterParams.SortOrder.ToLower() == "asc")
            {
                return cards.OrderBy(card => card.Name);
            }
            return cards;
        }
    }
}
