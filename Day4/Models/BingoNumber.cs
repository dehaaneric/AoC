namespace Day4.Models
{
    public class BingoNumber
    {
        public BingoNumber(int number, bool drawn)
        {
            Number = number;
            IsDrawn = drawn;
        }

        public int Number { get; }
        public bool IsDrawn { get; private set; }

        internal void SetDrawn()
        {
            this.IsDrawn = true;
        }
    }
}
