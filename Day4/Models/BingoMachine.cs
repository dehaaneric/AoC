namespace Day4.Models
{
    public class BingoMachine
    {
        public int StartFirstToWin(List<int> drawnNumbers, List<BingoCard> bingoCards)
        {
            foreach (var number in drawnNumbers)
            {
                foreach (var card in bingoCards)
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
            int totalBingoCards = bingoCards.Count;
            List<int> bingoCardIndexesWon = new List<int>();
            foreach (var number in drawnNumbers)
            {
                for (int cardIndex = 0; cardIndex < totalBingoCards; cardIndex++)
                {
                    var card = bingoCards[cardIndex];
                    bool hasHit = card.MarkDrawnNumber(number);

                    if (hasHit)
                    {
                        var hasRowOrColumn = card.GetHasFullRowOrColumn();
                        if (hasRowOrColumn && !bingoCardIndexesWon.Contains(cardIndex))
                        {
                            bingoCardIndexesWon.Add(cardIndex);
                        }

                        if (totalBingoCards == bingoCardIndexesWon.Count)
                        {
                            // the last
                            var totalUnmarkedNumbers = card.GetTotalNumberScore(false);
                            var result = number * totalUnmarkedNumbers;
                            return result;
                        }
                    }
                }
            }

            return -1;
        }
    }
}
