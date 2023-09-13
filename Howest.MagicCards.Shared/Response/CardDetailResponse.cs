using Howest.MagicCards.Shared.DTO;

namespace Howest.MagicCards.Shared.Response
{
    public class CardDetailResponse : IResponse
    {
        public string Message { get; set; }
        public CardDetailReadDTO CardDetail { get; set; }
    }
}
