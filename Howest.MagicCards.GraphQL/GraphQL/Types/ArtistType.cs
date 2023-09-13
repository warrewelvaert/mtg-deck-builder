using GraphQL.Types;
using Howest.MagicCards.DAL.Models;

namespace Howest.MagicCards.GraphQL.GraphQL.Types
{
    public class ArtistType : ObjectGraphType<Artist>
    {
        public ArtistType()
        {
            Field(s => s.Id).Description("Id of the artist.");
            Field(s => s.FullName).Description("Full name of the artist.");
            Field<ListGraphType<CardType>>(
                "Cards",
                resolve: context => context.Source.Cards.ToList(),
                description: "Cards of the artist."
            );
        }
    }
}
