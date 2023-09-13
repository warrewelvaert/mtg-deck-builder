using Howest.MagicCards.DAL.Models;

namespace Howest.MagicCards.DAL.Repositories
{
    #nullable enable
    public interface ISetRepository
    {
        IQueryable<Set> GetAllSets();
        Set? GetSetById(int id);
    }
}
