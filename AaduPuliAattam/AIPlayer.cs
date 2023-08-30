using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AaduPuliAattam
{
    internal interface AIPlayer : Player
    {
        void Play(Graph board);
    }
}
