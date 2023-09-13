using Howest.MagicCards.DAL.Models;

namespace Howest.MagicCards.DAL.Repositories
{
    # nullable enable
    public interface IColorRepository
    {
        IQueryable<Color> GetAllColors();
        Color? GetColorById(int id);
    }
}
