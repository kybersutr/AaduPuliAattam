namespace AaduPuliAattam
{
    internal class Lamb
    {
        public int TotalCount { get; private set; }
        public int PlacedCount { get; set; }
        public int CapturedCount { get; set; }
        public int selectedLambIndex = -1;

        public Lamb(int totalCount)
        {
            this.TotalCount = totalCount;
            this.PlacedCount = 0;
            this.CapturedCount = 0;
        }
    }
}