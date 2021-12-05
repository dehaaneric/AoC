// See https://aka.ms/new-console-template for more information
using Day4.Models;
using System.Text.RegularExpressions;

Console.WriteLine("Running task 1");
Task1();


Console.WriteLine("Running task 2");
Task2();


void Task2()
{
    List<int> drawnNumbers = GetDrawnNumbers();
    var cards = GetBingoCards();

    var bingoMachine = new BingoMachine();
    var score = bingoMachine.StartLastToWin(drawnNumbers, cards);

    Console.WriteLine($"Task 2 - Bingo machine output: {score}");
    Console.ReadLine();
}


void Task1()
{
    List<int> drawnNumbers = GetDrawnNumbers();
    var cards = GetBingoCards();

    var bingoMachine = new BingoMachine();
    var score = bingoMachine.StartFirstToWin(drawnNumbers, cards);

    Console.WriteLine($"Task 1 - Bingo machine output: {score}");
    Console.ReadLine();
}

List<int> GetDrawnNumbers()
{
    return new List<int>() { 37, 60, 87, 13, 34, 72, 45, 49, 61, 27, 97, 88, 50, 30, 76, 40, 63, 9, 38, 67, 82, 6, 59, 90, 99, 54, 11, 66, 98, 23, 64, 14, 18, 4, 10, 89, 46, 32, 19, 5, 1, 53, 25, 96, 2, 12, 86, 58, 41, 68, 95, 8, 7, 3, 85, 70, 35, 55, 77, 44, 36, 51, 15, 52, 56, 57, 91, 16, 71, 92, 84, 17, 33, 29, 47, 75, 80, 39, 83, 74, 73, 65, 78, 69, 21, 42, 31, 93, 22, 62, 24, 48, 81, 0, 26, 43, 20, 28, 94, 79 };
}

List<BingoCard> GetBingoCards()
{
    string[] input = System.IO.File.ReadAllLines(@"Day4Input.txt");

    List<BingoCard> cards = new List<BingoCard>();
    BingoCard currentCard = null;

    foreach (var line in input)
    {
        if (currentCard == null)
        {
            currentCard = new BingoCard();
        }
        if (string.IsNullOrWhiteSpace(line))
        {
            // begin new card
            if (currentCard != null)
            {
                cards.Add(currentCard);
                currentCard = new BingoCard();
            }
            continue;
        }
        var splittedStrings = Regex.Split(line.Trim(), @"\s{1,}");
        int[] split = splittedStrings.Select(int.Parse).ToArray();

        currentCard.AddNumbersToRow(currentCard.GetRowCount(), split);
    }

    if (currentCard != null)
    {
        cards.Add(currentCard);
    }

    return cards;
}