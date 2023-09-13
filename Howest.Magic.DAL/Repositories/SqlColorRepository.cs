using Howest.MagicCards.DAL.Models;

namespace Howest.MagicCards.DAL.Repositories
{
    # nullable enable
    internal class SqlColorRepository : IColorRepository
    {
        private readonly MtgV1Context _db;

        public SqlColorRepository(MtgV1Context mtgV1Context)
        {
            _db = mtgV1Context;
        }

        public IQueryable<Color> GetAllColors()
        {
            IQueryable<Color> allColors = _db.Colors
                                  .Select(a => a);
            return allColors;
        }

        public Color? GetColorById(int id)
        {
            Color? singleColor = _db.Colors
                        .SingleOrDefault(a => a.Id == id);

            return singleColor;
        }
    }
}
