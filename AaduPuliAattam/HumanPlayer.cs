using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AaduPuliAattam
{
    internal interface IHumanPlayer 
    {
        bool Play(Graph board, int buttonIndex);
    }
}
