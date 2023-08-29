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

        public void PlaceTigers(int n) 
        {
            for (int i = 0; i < n; i++) 
            {
                board.Vertices[i].occupiedBy = Vertex.Occupancy.TIGER;
            }
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
                        if (lamb.selectedLambIndex != -1) 
                        {
                            board.Vertices[lamb.selectedLambIndex].Selected = false;
                        }
                        lamb.selectedLambIndex = buttonIndex;
                        board.Vertices[lamb.selectedLambIndex].Selected = true;
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
                            board.Vertices[lamb.selectedLambIndex].Selected = false;
                            lamb.selectedLambIndex = -1;
                        }
                    }
                    this.turn = 1;
                }
            }
            else 
            {
                if (board.Vertices[buttonIndex].occupiedBy == Vertex.Occupancy.LAMB)
                {
                    return;
                }
                else if (board.Vertices[buttonIndex].occupiedBy == Vertex.Occupancy.TIGER)
                {
                    if (tiger.selectedTigerIndex != -1) 
                    {
                        board.Vertices[tiger.selectedTigerIndex].Selected = false;
                    }
                    tiger.selectedTigerIndex = buttonIndex;
                    board.Vertices[tiger.selectedTigerIndex].Selected = true;
                }
                else 
                {
                    if (tiger.selectedTigerIndex == -1) 
                    {
                        return;
                    }

                    if (board.Vertices[buttonIndex].Neighbors.Contains(board.Vertices[tiger.selectedTigerIndex]))
                    {
                        board.Vertices[buttonIndex].occupiedBy = Vertex.Occupancy.TIGER;
                        board.Vertices[tiger.selectedTigerIndex].occupiedBy = Vertex.Occupancy.NOTHING;
                        board.Vertices[tiger.selectedTigerIndex].Selected = false;
                        tiger.selectedTigerIndex = -1;
                        this.turn = 0;
                    }
                    else if (board.Vertices[buttonIndex].SkipOneNeighbors.Contains(board.Vertices[tiger.selectedTigerIndex])) 
                    {
                        Vertex between = board.Between[board.Vertices[buttonIndex]][board.Vertices[tiger.selectedTigerIndex]];

                        if (between.occupiedBy == Vertex.Occupancy.LAMB)
                        {
                            board.Vertices[tiger.selectedTigerIndex].occupiedBy = Vertex.Occupancy.NOTHING;
                            board.Vertices[buttonIndex].occupiedBy = Vertex.Occupancy.TIGER;
                            board.Vertices[tiger.selectedTigerIndex].Selected = false;
                            tiger.selectedTigerIndex = -1;
                            between.occupiedBy = Vertex.Occupancy.NOTHING;
                            lamb.CapturedCount += 1;

                            this.turn = 0;
                        }
                        else 
                        {
                            return; 
                        }
                    }
                    else 
                    {
                        return;
                    }
                }
           }
        }

    }
}
