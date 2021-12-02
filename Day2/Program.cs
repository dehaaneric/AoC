using BenchmarkDotNet.Running;
using Day2;

var summery = BenchmarkRunner.Run(typeof(Day2Task2));
Console.WriteLine(summery);


//var day2task1 = new Day2Task1();
//var total1 = day2task1.Calculate();

//Console.WriteLine($"Final score: {total1}"); // 2039912


//var day2task2 = new Day2Task2();
//var total2 = day2task2.CalculateOO();
//var total2Functional = day2task2.CalculateFunctional();

//Console.WriteLine($"Final score: {total2}"); // 2039912
