using Howest.MagicCards.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Howest.MagicCards.DAL.Repositories
{
    #nullable enable
    public class SqlArtistRepository : IArtistRepository
    {
        private readonly MtgV1Context _db;

        public SqlArtistRepository(MtgV1Context mtgV1Context)
        {
            _db = mtgV1Context;
        }

        public IQueryable<Artist> GetAllArtists()
        {
            IQueryable<Artist> allArtists = _db.Artists
                                                .Include(a => a.Cards)
                                                .Select(a => a);
            return allArtists;
        }

        public Artist? GetArtistById(int id)
        {
            Artist? singleArtist = _db.Artists
                                        .Include(a => a.Cards)
                                        .SingleOrDefault(a => a.Id == id);

            return singleArtist;
        }
    }
}
