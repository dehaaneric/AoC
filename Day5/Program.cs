// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Running;
using Day5;

var summary = BenchmarkRunner.Run(typeof(DataGridCalculator));
Console.WriteLine(summary);

//var calculator = new DataGridCalculator();
//var count = calculator.CalculateV3();
//Console.WriteLine($"calc result 3: {count}");

//calculator = new DataGridCalculator();
//count = calculator.CalculateV4();
//Console.WriteLine($"calc result 4: {count}");

//calculator = new DataGridCalculator();
//count = calculator.CalculateV3();
//Console.WriteLine($"calc result 3: {count}");

//calculator = new DataGridCalculator();
//count = calculator.CalculateV4();
//Console.WriteLine($"calc result 4: {count}");

Console.ReadLine();

