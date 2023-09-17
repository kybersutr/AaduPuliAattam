﻿using System;
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
                switch (board.Vertices[i].occupiedBy) 
                {
                    case Vertex.Occupancy.TIGER:
                        AI.OccupiedIndicesT.Add(i);
                        if (human is Tiger)
                        {
                            ((Tiger)human).OccupiedIndicesT.Add(i);
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

            if (AI.CapturedCount >= AI.Treshold) 
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
                if (human is Tiger)
                {
                    for (int i = 0; i < board.Vertices.Count; ++i) 
                    {
                        if ((AI.OccupiedIndicesL.Contains(i)) & (board.Vertices[i].occupiedBy == Vertex.Occupancy.NOTHING)) 
                        {
                            AI.OccupiedIndicesL.Remove(i);
                        }
                    }
                    AI.CapturedCount = ((Tiger)human).CapturedCount;
                    AI.OccupiedIndicesT = ((Tiger)human).OccupiedIndicesT;
                }
                else 
                {
                    for (int i = 0; i < board.Vertices.Count; ++i) 
                    {
                        if ((((Lamb)human).OccupiedIndicesL.Contains(i)) & (board.Vertices[i].occupiedBy == Vertex.Occupancy.NOTHING)) 
                        {
                            ((Lamb)human).OccupiedIndicesL.Remove(i);
                        }
                    }
                    AI.OccupiedIndicesL = ((Lamb)human).OccupiedIndicesL;
                    AI.PlacedCount = ((Lamb)human).PlacedCount;
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
