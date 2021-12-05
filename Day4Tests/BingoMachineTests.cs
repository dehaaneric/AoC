using Day4.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace Day4Tests
{
    public class BingoMachineTests
    {
        [Fact]
        public void BingoMachine_FirstToWin_HasExpectedOutput()
        {
            List<int> drawnNumbers = GetSampleDrawnNumbers();

            var bingoCards = GetSampleBingoCards();

            var machine = new BingoMachine();
            var score = machine.StartFirstToWin(drawnNumbers, bingoCards);

            Assert.Equal(4512, score);
        }

        [Fact]
        public void BingoMachine_LastToWin_HasExpectedOutput()
        {
            List<int> drawnNumbers = GetSampleDrawnNumbers();

            var bingoCards = GetSampleBingoCards();

            var machine = new BingoMachine();
            var score = machine.StartLastToWin(drawnNumbers, bingoCards);

            Assert.Equal(1924, score);
        }

        private List<BingoCard> GetSampleBingoCards()
        {
            List<BingoCard> bingoCards = new List<BingoCard>(3);

            var bingoCard1 = new BingoCard();
            bingoCard1.AddNumbersToRow(0, 22, 13, 17, 11, 0);
            bingoCard1.AddNumbersToRow(1, 8, 2, 23, 4, 24);
            bingoCard1.AddNumbersToRow(2, 21, 9, 14, 16, 7);
            bingoCard1.AddNumbersToRow(3, 6, 10, 3, 18, 5);
            bingoCard1.AddNumbersToRow(4, 1, 12, 20, 15, 19);
            bingoCards.Add(bingoCard1);

            var bingoCard2 = new BingoCard();
            bingoCard2.AddNumbersToRow(0, 3, 15, 0, 2, 22);
            bingoCard2.AddNumbersToRow(1, 9, 18, 13, 17, 5);
            bingoCard2.AddNumbersToRow(2, 19, 8, 7, 25, 23);
            bingoCard2.AddNumbersToRow(3, 20, 11, 10, 24, 4);
            bingoCard2.AddNumbersToRow(4, 14, 21, 16, 12, 6);
            bingoCards.Add(bingoCard2);

            var bingoCard3 = new BingoCard();
            bingoCard3.AddNumbersToRow(0, 14, 21, 17, 24, 4);
            bingoCard3.AddNumbersToRow(1, 10, 16, 15, 9, 19);
            bingoCard3.AddNumbersToRow(2, 18, 8, 23, 26, 20);
            bingoCard3.AddNumbersToRow(3, 22, 11, 13, 6, 5);
            bingoCard3.AddNumbersToRow(4, 2, 0, 12, 3, 7);
            bingoCards.Add(bingoCard3);

            return bingoCards;
        }

        private List<int> GetSampleDrawnNumbers()
        {
            return new List<int>() { 7, 4, 9, 5, 11, 17, 23, 2, 0, 14, 21, 24, 10, 16, 13, 6, 15, 25, 12, 22, 18, 20, 8, 19, 3, 26, 1 };
        }
    }
}