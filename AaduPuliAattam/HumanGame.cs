using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AaduPuliAattam
{
    internal class HumanGame : Game
    {

        private HumanLamb lamb;
        private HumanTiger tiger;
        private int turn = 0; // 0 = lamb, 1 = tiger

        public HumanGame(Graph board, HumanLamb lamb, HumanTiger tiger)
        {
            this.board = board;
            this.lamb = lamb;
            this.tiger = tiger;

            FindOccupiedByTiger();
        }

        private void FindOccupiedByTiger()
        {
            for (int i = 0; i < board.Vertices.Count; ++i) 
            {
                if (board.Vertices[i].occupiedBy == Vertex.Occupancy.TIGER)
                {
                    tiger.OccupiedIndicesT.Add(i);
                }
            }
        }

        public void PlaceTigers(int n) 
        {
            for (int i = 0; i < n; i++) 
            {
                board.Vertices[i].occupiedBy = Vertex.Occupancy.TIGER;
                tiger.OccupiedIndicesT.Add(i);
            }
        }
        public override void HandleButtonClick(int buttonIndex) 
        {
            if (turn == 0)
            {
                if (lamb.Play(board, buttonIndex)) 
                {
                    this.turn = 1;
                } 
            }
            else 
            {
                if (tiger.Play(board, buttonIndex)) 
                {
                    this.turn = 0;
                } 
            }
        }

        public override int CheckForWin()
        {
            // TODO: It's possible that tigers will have possible move after a lamb has to move...
            // -1 = no winner
            // 0 = lamb wins
            // 1 = tiger wins

            if (tiger.CapturedCount >= tiger.Treshold) 
            {
                return 1;
            }
            if (!tiger.HasLegalMoves(board)) 
            {
                return 0;
            }
            return -1;
        }

        public override GameStatus GetStatus()
        {
            int lambsPlaced = lamb.TotalCount - lamb.PlacedCount;
            int capturedCount = tiger.CapturedCount;
            bool lambTurn = (turn == 0);

            return new GameStatus(lambsPlaced, capturedCount, lambTurn);
        }
    }
}
