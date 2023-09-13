namespace Howest.MagicCards.Shared.Response
{
    public class DeckResponse<T> : IResponse
    {
        public string Message { get; set; }
        public T Deck { get; set; }
    }
}
