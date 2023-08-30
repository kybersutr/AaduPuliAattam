using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AaduPuliAattam
{
    internal interface HumanPlayer : Player
    {
        bool Play(Graph board, int buttonIndex);
    }
}
