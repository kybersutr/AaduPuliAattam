﻿namespace AaduPuliAattam
{
    internal class HumanTiger : Tiger, HumanPlayer
    {
        public int selectedTigerIndex = -1;
        public List<int> occupiedIndices = new List<int>();
        public int CapturedCount = 0;
        public int treshold { get; private set; }

        public HumanTiger(int treshold)
        {
            this.treshold = treshold;
        }

        public bool HasLegalMoves(Graph board) 
        {
            foreach (int i in occupiedIndices) 
            {
                foreach (Vertex neighbor in board.Vertices[i].Neighbors) 
                {
                    if (neighbor.occupiedBy == Vertex.Occupancy.NOTHING) 
                    {
                        return true;
                    }
                }

                foreach (Vertex skipNeighbor in board.Vertices[i].SkipOneNeighbors) 
                {
                    if ((skipNeighbor.occupiedBy == Vertex.Occupancy.NOTHING) & 
                        (board.Between[board.Vertices[i]][skipNeighbor].occupiedBy == Vertex.Occupancy.LAMB)) 
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool Play(Graph board, int buttonIndex)
        {
            // Returns true if move has been made, false otherwise.
            if (board.Vertices[buttonIndex].occupiedBy == Vertex.Occupancy.LAMB)
            {
                return false;
            }
            else if (board.Vertices[buttonIndex].occupiedBy == Vertex.Occupancy.TIGER)
            {
                if (selectedTigerIndex != -1)
                {
                    board.Vertices[selectedTigerIndex].Selected = false;
                }
                selectedTigerIndex = buttonIndex;
                board.Vertices[selectedTigerIndex].Selected = true;
                return false;
            }
            else
            {
                if (selectedTigerIndex == -1)
                {
                    return false;
                }

                if (board.Vertices[buttonIndex].Neighbors.Contains(board.Vertices[selectedTigerIndex]))
                {
                    board.Vertices[buttonIndex].occupiedBy = Vertex.Occupancy.TIGER;
                    occupiedIndices.Add(buttonIndex);
                    board.Vertices[selectedTigerIndex].occupiedBy = Vertex.Occupancy.NOTHING;
                    occupiedIndices.Remove(selectedTigerIndex);
                    board.Vertices[selectedTigerIndex].Selected = false;
                    selectedTigerIndex = -1;
                    return true;
                }
                else if (board.Vertices[buttonIndex].SkipOneNeighbors.Contains(board.Vertices[selectedTigerIndex]))
                {
                    Vertex between = board.Between[board.Vertices[buttonIndex]][board.Vertices[selectedTigerIndex]];

                    if (between.occupiedBy == Vertex.Occupancy.LAMB)
                    {
                        board.Vertices[selectedTigerIndex].occupiedBy = Vertex.Occupancy.NOTHING;
                        occupiedIndices.Remove(selectedTigerIndex);
                        board.Vertices[buttonIndex].occupiedBy = Vertex.Occupancy.TIGER;
                        occupiedIndices.Add(buttonIndex);
                        board.Vertices[selectedTigerIndex].Selected = false;
                        selectedTigerIndex = -1;
                        between.occupiedBy = Vertex.Occupancy.NOTHING;
                        CapturedCount += 1;

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
        }
    }
}