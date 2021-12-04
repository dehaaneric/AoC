// See https://aka.ms/new-console-template for more information
using Day3;

Console.WriteLine("Hello, World!");

string[] input = System.IO.File.ReadAllLines(@"Day3Input.txt");

Submarine submarine = new Submarine();
var result1 = submarine.Calculate_Task1(input);

Console.Write($"Calculated result Task 1: {result1}");
Console.ReadLine();


var result2 = submarine.Calculate_Task2(input);

Console.Write($"Calculated result Task 2: {result2}");
Console.ReadLine();
