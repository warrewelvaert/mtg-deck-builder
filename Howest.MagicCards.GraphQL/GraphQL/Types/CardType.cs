using GraphQL.Types;
using Howest.MagicCards.DAL.Models;
using Howest.MagicCards.Shared.DTO;

namespace Howest.MagicCards.GraphQL.GraphQL.Types
{
    public class CardType : ObjectGraphType<Card>
    {
        public CardType()
        {
            Field(s => s.Id).Description("Id of the card.");
            Field(s => s.Name).Description("Name of the card.");
            Field(s => s.Type).Description("Type of the card.");

            Field<SetType>(
            "set",
                description: "Set of the card.",
                resolve: c => c.Source.SetCodeNavigation
            );
            Field<ArtistType>(
            "artist",
                description: "Artist of the card.",
                resolve: c => c.Source.Artist
            );
            Field<RarityType>(
            "rarity",
                description: "Rarity of the card.",
                resolve: c => c.Source.RarityCodeNavigation
            );
            Field<StringGraphType>(
            "flavor",
                description: "Flavor text of the card.",
                resolve: c => c.Source.Flavor
            );
            Field<StringGraphType>(
            "text",
                description: "Text of the card.",
                resolve: c => c.Source.Text
            );
            Field<StringGraphType>(
            "image",
                description: "URL to the image of the card.",
                resolve: c => c.Source.OriginalImageUrl
            );
            Field<StringGraphType>(
            "manaCost",
                description: "Mana cost of the card.",
                resolve: c => c.Source.ManaCost
            );
            Field<StringGraphType>(
                "power",
                description: "Power of the card.",
                resolve: c => c.Source.Power
            );
            Field<StringGraphType>(
                "toughness",
                description: "Toughness of the card.",
                resolve: c => c.Source.Toughness
            );
        }
    }
}
