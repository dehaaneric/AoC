namespace Day4.Models
{
    public class BingoMachine
    {
        public int StartFirstToWin(List<int> drawnNumbers, List<BingoCard> bingoCards)
        {
            foreach (int number in drawnNumbers)
            {
                foreach (BingoCard card in bingoCards)
                {
                    bool hasHit = card.MarkDrawnNumber(number);

                    if (hasHit)
                    {
                        var hasRowOrColumn = card.GetHasFullRowOrColumn();
                        if (hasRowOrColumn)
                        {
                            var totalUnmarkedNumbers = card.GetTotalNumberScore(false);
                            var result = number * totalUnmarkedNumbers;
                            return result;
                        }
                    }
                }
            }

            return -1;
        }

        public int StartLastToWin(List<int> drawnNumbers, List<BingoCard> bingoCards)
        {
            var totalBingoCards = bingoCards.Count;
            
            foreach (var number in drawnNumbers)
            {
                foreach(var card in bingoCards)
                {
                    bool hasHit = card.MarkDrawnNumber(number);

                    if (hasHit)
                    {
                        var hasRowOrColumn = card.GetHasFullRowOrColumn();
                        if (hasRowOrColumn)
                            card.MarkAsWon();

                        bool isTheLastToWin = totalBingoCards == bingoCards.Where(x => x.HasWon).Count();
                        if (isTheLastToWin)
                        {
                            var totalUnmarkedNumbers = card.GetTotalNumberScore(false);
                            var result = number * totalUnmarkedNumbers;
                            return result;
                        }
                    }
                }
            }

            throw new ApplicationException("Unexpected end of events");
        }
    }
}
