using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AaduPuliAattam
{
    internal class GameStatus
    {
        public int lambsToPlace;
        public int lambsCaptured;
        public bool lambsTurn;

        public GameStatus(int lambsToPlace, int lambsCaptured, bool lambsTurn)
        {
            this.lambsToPlace = lambsToPlace;
            this.lambsCaptured = lambsCaptured;
            this.lambsTurn = lambsTurn;
        }
    }
}
