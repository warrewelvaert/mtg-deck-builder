using Howest.MagicCards.Shared.DTO;

namespace Howest.MagicCards.Shared.Response
{
    public class MagicCardsResponse: IResponse
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public List<CardReadDTO> Cards { get; set; } = new List<CardReadDTO>();
        public string Message { get; set; }
    }
}
