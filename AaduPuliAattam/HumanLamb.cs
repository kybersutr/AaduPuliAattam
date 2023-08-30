namespace AaduPuliAattam
{
    internal class HumanLamb : Lamb, HumanPlayer
    {
        public int TotalCount { get; private set; }
        public int PlacedCount { get; set; }
        public int selectedLambIndex = -1;

        public List<int> occupiedIndices = new List<int>();

        public HumanLamb(int totalCount)
        {
            this.TotalCount = totalCount;
            this.PlacedCount = 0;
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
                        board.Vertices[selectedLambIndex].occupiedBy = Vertex.Occupancy.NOTHING;
                        board.Vertices[selectedLambIndex].Selected = false;
                        selectedLambIndex = -1;
                        return true;
                    }
                }
            }
        }
    }
}