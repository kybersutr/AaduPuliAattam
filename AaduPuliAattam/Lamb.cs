using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AaduPuliAattam
{
    internal interface Lamb
    {
        public int PlacedCount {get; set;}
        public int TotalCount { get; set; }

        public List<int> OccupiedIndicesL { get; set; }
    }
}
