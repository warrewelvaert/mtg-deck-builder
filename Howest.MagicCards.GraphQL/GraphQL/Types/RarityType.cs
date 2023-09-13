using GraphQL.Types;
using Howest.MagicCards.DAL.Models;

namespace Howest.MagicCards.GraphQL.GraphQL.Types
{
    public class RarityType : ObjectGraphType<Rarity>
    {
        public RarityType()
        {
            Field(s => s.Id).Description("Id of the Rarity.");
            Field(s => s.Name).Description("Name of the Rarity.");
            Field(s => s.Code).Description("Code of the Rarity.");
        }
    }
}
