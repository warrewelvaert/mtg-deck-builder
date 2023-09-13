using GraphQL.Types;
using Howest.MagicCards.DAL.Models;

namespace Howest.MagicCards.GraphQL.GraphQL.Types
{
    public class SetType : ObjectGraphType<Set>
    {
        public SetType()
        {
            Field(s => s.Id).Description("Id of the set.");
            Field(s => s.Name).Description("Name of the set.");
            Field(s => s.Code).Description("Code of the set.");
        }    
    }
}
