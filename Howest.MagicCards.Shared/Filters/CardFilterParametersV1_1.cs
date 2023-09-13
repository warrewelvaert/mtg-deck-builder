using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Howest.MagicCards.Shared.Filters
{
    public class CardFilterParametersV1_1
    {
        public string Name { get; set; }
        public string Set { get; set; }
        public string Text { get; set; }
        public string Artist { get; set; }
        public string Rarity { get; set; }
        public string Type { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 150;
    }
}
