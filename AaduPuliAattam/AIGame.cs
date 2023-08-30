using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AaduPuliAattam
{
    internal class AIGame
    {
        public Graph board;
        private HumanPlayer human;
        private AIPlayer AI;

        public AIGame(Graph board, HumanPlayer human, AIPlayer AI)
        {
            this.board = board;
            this.human = human;
            this.AI = AI;

            if (human is Tiger) 
            {
                AI.Play(board);
            }
        }

        public void HandleButtonClick(int buttonIndex) 
        {
            if (human.Play(board, buttonIndex)) 
            {
                AI.Play(board);
            }
        }
    }
}
