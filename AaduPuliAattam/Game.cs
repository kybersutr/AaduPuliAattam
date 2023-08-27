using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AaduPuliAattam
{
    internal class Game
    {

        public Graph board;
        private Player player1;
        private Player player2;


        public Game(Graph board, Player player1, Player player2)
        {
            this.board = board;
            this.player1 = player1;
            this.player2 = player2;
        }
        public void HandleButtonClick(int buttonIndex) 
        {
            board.Vertices[buttonIndex].occupiedBy = Vertex.Occupancy.TIGER;
        }

    }
}
