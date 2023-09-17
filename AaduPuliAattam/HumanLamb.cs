namespace AaduPuliAattam
{
    internal class HumanLamb : ILamb, HumanPlayer
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
            if (board.Vertices[buttonIndex].occupiedBy == Vertex.Occupancy.TIGER)
            {
                return false;
            }
            else if (board.Vertices[buttonIndex].occupiedBy == Vertex.Occupancy.LAMB)
            {
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
                    board.Vertices[buttonIndex].occupiedBy = Vertex.Occupancy.LAMB;
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
                        board.Vertices[buttonIndex].occupiedBy = Vertex.Occupancy.LAMB;
                        OccupiedIndicesL.Add(buttonIndex);
                        board.Vertices[selectedLambIndex].occupiedBy = Vertex.Occupancy.NOTHING;
                        OccupiedIndicesL.Remove(buttonIndex);
                        board.Vertices[selectedLambIndex].Selected = false;
                        selectedLambIndex = -1;
                        return true;
                    }
                }
            }
        }
    }
}