using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4.Models
{
    public class BingoCard
    {
        Dictionary<int, List<BingoNumber>> _rows = new Dictionary<int, List<BingoNumber>>(5);
        public void AddNumbersToRow(int rowIndex, params int[] numbers)
        {
            _rows.Add(rowIndex, numbers.Select(x => new BingoNumber(x, false)).ToList());
        }
        int numberOfDraws = 0;
        public bool MarkDrawnNumber(int drawnNumber)
        {
            numberOfDraws++;

            bool hasHit = false;
            foreach (var kvp in _rows)
            {
                var bingoNumber = kvp.Value.SingleOrDefault(x => x.Number == drawnNumber);
                if (bingoNumber != null)
                {
                    hasHit = true;
                    bingoNumber.SetDrawn();
                }
            }

            return hasHit;
        }

        public bool GetHasFullRowOrColumn()
        {
            int numberOfItemsInRow = _rows.Values.First().Count;
            int numberOfRows = _rows.Values.Count;

            // completed rows
            foreach (var kvp in _rows)
            {
                var markedNumbers = kvp.Value.Where(x => x.IsDrawn).Count();
                if (markedNumbers == numberOfItemsInRow)
                    return true;
            }

            // completed columns
            for (int columnIndex = 0; columnIndex < numberOfItemsInRow; columnIndex++)
            {
                bool hasAllInColumnMarked = true;
                for (int rowIndex = 0; rowIndex < numberOfRows; rowIndex++)
                {
                    bool isDrawn = _rows[rowIndex][columnIndex].IsDrawn;
                    if (!isDrawn)
                        hasAllInColumnMarked = false;
                }

                if (hasAllInColumnMarked)
                    return true;
            }

            return false;
        }

        public int GetTotalNumberScore(bool expectedDrawnValue)
        {
            int sumScore = 0;
            foreach(var row in _rows)
            {
                foreach(var bingoNumber in row.Value)
                {
                    if(bingoNumber.IsDrawn == expectedDrawnValue)
                    {
                        sumScore += bingoNumber.Number;
                    }
                }
            }

            return sumScore;
        }

        public int GetRowCount()
        {
            return _rows.Count;
        }
    }

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
