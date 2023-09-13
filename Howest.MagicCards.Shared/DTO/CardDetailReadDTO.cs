using Howest.MagicCards.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Howest.MagicCards.Shared.DTO
{
    public record CardDetailReadDTO()
    {
        public long Id { get; init; }
        public string Name { get; init; }
        public string Text { get; init; }
        public string OriginalImageUrl { get; init; }
        public string Rarity { get; init; }
        public string Set { get; init; }
        public string Type { get; init; }
        public string ManaCost { get; init; }
        public string ConvertedManaCost { get; init;}
    }
}
