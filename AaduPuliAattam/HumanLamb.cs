namespace AaduPuliAattam
{
    internal class HumanLamb : ILamb, IHumanPlayer
    {
        public int TotalCount { get; set; }
        public int PlacedCount { get; set; }
        public int selectedLambIndex = -1;

        public List<int> OccupiedIndicesL { get; set; }
        public HumanLamb(int totalCount)
        {
            this.TotalCount = totalCount;
            this.PlacedCount = 0;
            OccupiedIndicesL = new List<int> { };
        }

        public bool Play(Graph board, int buttonIndex)
        {
            // Return true if move has been made, false otherwise.
            // AI player needs to know this.
            if (board.Vertices[buttonIndex].OccupiedBy == Vertex.Occupancy.TIGER)
            {
                return false;
            }
            else if (board.Vertices[buttonIndex].OccupiedBy == Vertex.Occupancy.LAMB)
            {
                // Lambs can start moving once each one is placed on the board.
                if (PlacedCount < TotalCount)
                {
                    return false;
                }
                else
                {
                    if (selectedLambIndex != -1)
                    {
                        board.Vertices[selectedLambIndex].Selected = false;
                    }
                    selectedLambIndex = buttonIndex;
                    board.Vertices[selectedLambIndex].Selected = true;
                    return false;
                }
            }
            else
            {
                if (PlacedCount < TotalCount)
                {
                    board.Vertices[buttonIndex].OccupiedBy = Vertex.Occupancy.LAMB;
                    OccupiedIndicesL.Add(buttonIndex);
                    PlacedCount++;
                    return true;
                }
                else
                {
                    if (selectedLambIndex == -1)
                    {
                        return false;
                    }
                    else
                    {
                        if (!board.Vertices[buttonIndex].Neighbors.Contains(board.Vertices[selectedLambIndex]))
                        {
                            return false;
                        }
                        board.Vertices[buttonIndex].OccupiedBy = Vertex.Occupancy.LAMB;
                        OccupiedIndicesL.Add(buttonIndex);
                        board.Vertices[selectedLambIndex].OccupiedBy = Vertex.Occupancy.NOTHING;
                        OccupiedIndicesL.Remove(buttonIndex);
                        board.Vertices[selectedLambIndex].Selected = false;
                        selectedLambIndex = -1;
                        return true;
                    }
                }
            }
        }

        internal bool HasLegalMoves(Graph board)
        {
            if (this.PlacedCount < this.TotalCount)
            {
                foreach (Vertex v in board.Vertices) 
                {
                    if (v.OccupiedBy == Vertex.Occupancy.NOTHING) 
                    {
                        return true;
                    }
                }
            }
            else 
            {
                foreach (int lambIndex in OccupiedIndicesL) 
                {
                    foreach (Vertex neighbor in board.Vertices[lambIndex].Neighbors) 
                    {
                        if (neighbor.OccupiedBy == Vertex.Occupancy.NOTHING) 
                        {
                            return true;
                        }
                    }
                }
            }

            return false;

        }
    }
}