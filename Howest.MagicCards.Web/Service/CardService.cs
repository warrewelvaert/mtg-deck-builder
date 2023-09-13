using Howest.MagicCards.DAL.Models;
using Howest.MagicCards.DAL.Repositories;
using Howest.MagicCards.Shared.DTO;
using Howest.MagicCards.Shared.Response;


namespace Howest.MagicCards.Web.Service
{
    public class CardService
    {
        public readonly string _apiVersion = "v1.5";
        public readonly string _deckBaseUri = "api/Deck/v1.5/";
        public readonly string _minimalDeckBaseUri = "api/Deck/";
    }
}
