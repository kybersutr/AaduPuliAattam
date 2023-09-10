using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AaduPuliAattam
{
    internal abstract class Game
    {
        internal Graph board;

        public abstract int CheckForWin();

        public abstract void HandleButtonClick(int i);
    }
}
