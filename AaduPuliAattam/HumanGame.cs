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
        private Lamb lamb;
        private Tiger tiger;
        private int turn = 0; // 0 = lamb, 1 = tiger

        public HumanGame(Graph board, Lamb lamb, Tiger tiger)
        {
            this.board = board;
            this.lamb = lamb;
            this.tiger = tiger;
        }
        public void HandleButtonClick(int buttonIndex) 
        {
            if (turn == 0)
            {
                if (board.Vertices[buttonIndex].occupiedBy == Vertex.Occupancy.TIGER)
                {
                    return;
                }
                else if (board.Vertices[buttonIndex].occupiedBy == Vertex.Occupancy.LAMB)
                {
                    if (lamb.PlacedCount < lamb.TotalCount)
                    {
                        return;
                    }
                    else 
                    {
                        lamb.selectedLambIndex = buttonIndex;
                    }
                }
                else 
                {
                    if (lamb.PlacedCount < lamb.TotalCount)
                    {
                        board.Vertices[buttonIndex].occupiedBy = Vertex.Occupancy.LAMB;
                        lamb.PlacedCount++;
                    }
                    else 
                    {
                        if (lamb.selectedLambIndex == -1)
                        {
                            return;
                        }
                        else 
                        {
                            if (!board.Vertices[buttonIndex].Neighbors.Contains(board.Vertices[lamb.selectedLambIndex])) 
                            {
                                return;
                            }
                            board.Vertices[buttonIndex].occupiedBy = Vertex.Occupancy.LAMB;
                            board.Vertices[lamb.selectedLambIndex].occupiedBy = Vertex.Occupancy.NOTHING;
                            lamb.selectedLambIndex = -1;
                        }
                    }
                    this.turn = 1;
                }
            }
            else 
            {
                board.Vertices[buttonIndex].occupiedBy = Vertex.Occupancy.TIGER;
                this.turn = 0;
            }
        }

    }
}
