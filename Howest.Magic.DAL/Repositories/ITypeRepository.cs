using Type = Howest.MagicCards.DAL.Models.Type;

namespace Howest.MagicCards.DAL.Repositories
{
    #nullable enable
    public interface ITypeRepository
    {
        IQueryable<Type> GetAllTypes();
        Type? GetTypeById(int id);
    }
}
