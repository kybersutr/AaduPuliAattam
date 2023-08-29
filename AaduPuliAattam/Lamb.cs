namespace AaduPuliAattam
{
    internal class Lamb
    {
        public int TotalCount { get; private set; }
        public int PlacedCount { get; set; }
        public int CapturedCount { get; set; }
        public int selectedLambIndex = -1;
        public int treshold { get; private set; }

        public List<int> occupiedIndices = new List<int>();

        public Lamb(int totalCount, int treshold)
        {
            this.TotalCount = totalCount;
            this.PlacedCount = 0;
            this.CapturedCount = 0;
            this.treshold = treshold;
        }
    }
}