using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AaduPuliAattam
{
    internal class AIGame : Game
    {
        private HumanPlayer human;
        private AIPlayer AI;

        public AIGame(Graph board, HumanPlayer human, AIPlayer AI)
        {
            this.board = board;
            this.human = human;
            this.AI = AI;

            FindOccupied();

            if (human is Tiger) 
            {
                AI.Play(board);
            }

        }

        private void FindOccupied()
        {
            for (int i = 0; i < board.Vertices.Count; ++i) 
            {
                // TODO: Could have been a switch.
                if (board.Vertices[i].occupiedBy == Vertex.Occupancy.TIGER)
                {
                    AI.OccupiedIndicesT.Add(i);
                    if (human is Tiger)
                    {
                        ((Tiger)human).OccupiedIndicesT.Add(i);
                    }
                }
                else if (board.Vertices[i].occupiedBy == Vertex.Occupancy.LAMB) 
                {
                    AI.OccupiedIndicesL.Add(i);
                }
            }    
        }

        public override int CheckForWin()
        {
            return -1;
        }

        public override void HandleButtonClick(int buttonIndex) 
        {
            if (human.Play(board, buttonIndex)) 
            {
                if (human is Tiger) 
                {
                    AI.CapturedCount = ((Tiger)human).CapturedCount;
                    AI.OccupiedIndicesT = ((Tiger)human).OccupiedIndicesT;
                }
                AI.Play(board);
            }
        }

        public override GameStatus GetStatus()
        {
            int lambsPlaced = AI.TotalCount - AI.PlacedCount;
            int lambsCaptured = AI.CapturedCount;
            bool lambMove = (human is Lamb);

            return new GameStatus(lambsPlaced, lambsCaptured, lambMove);
        }
    }
}
