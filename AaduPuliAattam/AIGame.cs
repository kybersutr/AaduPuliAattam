using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AaduPuliAattam
{
    internal class AIGame : Game
    {
        private IHumanPlayer human;
        private AIPlayer AI;

        public AIGame(Graph board, IHumanPlayer human, AIPlayer AI)
        {
            this.board = board;
            this.human = human;
            this.AI = AI;

            FindOccupied();

            if (human is ITiger) 
            {
                AI.Play(board);
            }

        }

        private void FindOccupied()
        {
            for (int i = 0; i < board.Vertices.Count; ++i) 
            {
                switch (board.Vertices[i].OccupiedBy) 
                {
                    case Vertex.Occupancy.TIGER:
                        AI.OccupiedIndicesT.Add(i);
                        if (human is ITiger)
                        {
                            ((ITiger)human).OccupiedIndicesT.Add(i);
                        }
                        break;
                    case Vertex.Occupancy.LAMB:
                        AI.OccupiedIndicesL.Add(i);
                        break;
                    default:
                        break;
                }
            }    
        }

        public override int CheckForWin()
        {
            // -1 = no winner
            // 0 = lamb wins
            // 1 = tiger wins

            if ((AI.CapturedCount >= AI.Treshold) | !AI.LambHasMoves(board)) 
            {
                return 1;
            }
            if (!AI.TigerHasMoves(board)) 
            {
                return 0;
            }
            return -1;
        }

        public override void HandleButtonClick(int buttonIndex) 
        {
            if (human.Play(board, buttonIndex)) 
            {
                if (CheckForWin() != -1) 
                {
                    return;
                }
                if (human is ITiger)
                {
                    for (int i = 0; i < board.Vertices.Count; ++i) 
                    {
                        if ((AI.OccupiedIndicesL.Contains(i)) & (board.Vertices[i].OccupiedBy == Vertex.Occupancy.NOTHING)) 
                        {
                            AI.OccupiedIndicesL.Remove(i); // lamb has been captured
                        }
                    }
                    AI.CapturedCount = ((ITiger)human).CapturedCount;
                    AI.OccupiedIndicesT = ((ITiger)human).OccupiedIndicesT;

                    AI.Play(board);
                }
                else 
                {
                    AI.OccupiedIndicesL = ((ILamb)human).OccupiedIndicesL;
                    AI.PlacedCount = ((ILamb)human).PlacedCount;

                    AI.Play(board); 
                    
                    for (int i = 0; i < board.Vertices.Count; ++i) 
                    {
                        if ((((ILamb)human).OccupiedIndicesL.Contains(i)) & (board.Vertices[i].OccupiedBy == Vertex.Occupancy.NOTHING)) 
                        {
                            ((ILamb)human).OccupiedIndicesL.Remove(i); // lamb has been captured
                        }
                    }
                }
            }
        }

        public override GameStatus GetStatus()
        {
            int lambsPlaced = AI.TotalCount - AI.PlacedCount;
            int lambsCaptured = AI.CapturedCount;
            bool lambMove = (human is ILamb);

            return new GameStatus(lambsPlaced, lambsCaptured, lambMove);
        }
    }
}
