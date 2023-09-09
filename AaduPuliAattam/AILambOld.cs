using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AaduPuliAattam
{
    internal class AILambOld : Lamb, AIPlayerOld
    {
        public int PlacedCount { get; set; }
        public int TotalCount { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Play(Graph board)
        {
            throw new NotImplementedException();
        }
    }
}
