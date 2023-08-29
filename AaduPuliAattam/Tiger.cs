namespace AaduPuliAattam
{
    internal class Tiger
    {
        public int selectedTigerIndex = -1;
        public List<int> occupiedIndices = new List<int>();

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
    }
}