using BenchmarkDotNet.Running;
using Day1;

var summery = BenchmarkRunner.Run(typeof(Day1Task2));
Console.WriteLine(summery);

//string[] input = System.IO.File.ReadAllLines(@"day1input.txt");

//var day1Task1 = new Day1Task1();
//int generics = day1Task1.Generics();

//Console.WriteLine("Day 1");
//Console.WriteLine($"{nameof(generics)}: {generics}");

//int nonGenerics = day1Task1.NoGenerics();
//Console.WriteLine($"{nameof(nonGenerics)}: {nonGenerics}");
//Console.WriteLine();
//Console.WriteLine();

//Console.WriteLine("Day 2");
//var day1Task2 = new Day1Task2();

//int increasesWithGenerics = day1Task2.Generics();
//Console.WriteLine($"{nameof(increasesWithGenerics)}: {increasesWithGenerics}");

//int increasesWithoutGenerics = day1Task2.NoGenerics();
//Console.WriteLine($"{nameof(increasesWithoutGenerics)}: {increasesWithoutGenerics}");

//Console.WriteLine("Press the key");
//Console.ReadLine();

