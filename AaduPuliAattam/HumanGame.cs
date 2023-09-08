using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AaduPuliAattam
{
    internal class HumanGame
    {

        public Graph board;
        private HumanLamb lamb;
        private HumanTiger tiger;
        private int turn = 0; // 0 = lamb, 1 = tiger

        public HumanGame(Graph board, HumanLamb lamb, HumanTiger tiger)
        {
            this.board = board;
            this.lamb = lamb;
            this.tiger = tiger;
        }

        public void PlaceTigers(int n) 
        {
            for (int i = 0; i < n; i++) 
            {
                board.Vertices[i].occupiedBy = Vertex.Occupancy.TIGER;
                tiger.OccupiedIndices.Add(i);
            }
        }
        public void HandleButtonClick(int buttonIndex) 
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

        internal int CheckForWin()
        {
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
    }
}
