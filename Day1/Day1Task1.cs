using BenchmarkDotNet.Attributes;

namespace Day1
{
    [MemoryDiagnoser]
    public class Day1Task1
    {
        private int[] _measurements;

        public Day1Task1()
        {
            string[] input = System.IO.File.ReadAllLines(@"day1input.txt");
            _measurements = input.Select(int.Parse).ToArray();
        }
        /*
        https://github.com/dehaaneric/AoC
        |     Method |      Mean |     Error |    StdDev | Allocated |
        |----------- |----------:|----------:|----------:|----------:|
        |   Generics | 25.062 us | 0.4474 us | 0.7097 us |      48 B |
        | NoGenerics |  3.474 us | 0.0692 us | 0.1824 us |         - |
        */

        [Benchmark]
        public int Generics()
        {
            int totalIncreases = 0;

            int prevValue = _measurements.First();

            foreach (var measurement in _measurements.Skip(1))
            {
                if (prevValue < measurement) totalIncreases++;

                prevValue = measurement;
            }

            return totalIncreases;
        }

        [Benchmark]
        public int NoGenerics()
        {
            int totalCount = _measurements.Length;
            int totalIncreases = 0;
            int prevValue = -1;

            for (int index = 0; index < totalCount; index++)
            {
                var measurement = _measurements[index];
                if(prevValue < 0)
                {
                    // Set first
                    prevValue = measurement;
                    continue;
                }

                if (prevValue < measurement) totalIncreases++;

                prevValue = measurement;
            }

            return totalIncreases;
        }
    }
}
