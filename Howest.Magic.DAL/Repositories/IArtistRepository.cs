using Howest.MagicCards.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Howest.MagicCards.DAL.Repositories
{
    #nullable enable

    public interface IArtistRepository
    {
        IQueryable<Artist> GetAllArtists();
        Artist? GetArtistById(int id);
    }
}
