using BenchmarkDotNet.Attributes;

namespace Day1
{
[MemoryDiagnoser]
public class Day1Task2
{
    int[] _measurements;
    const int GroupingSize = 3;

    public Day1Task2()
    {
        string[] input = System.IO.File.ReadAllLines(@"day1input.txt");
        _measurements = input.Select(int.Parse).ToArray();
    }

    /*
        https://github.com/dehaaneric/AoC
    |     Method |      Mean |    Error |   StdDev |   Gen 0 | Allocated |
    |----------- |----------:|---------:|---------:|--------:|----------:|
    |   Generics | 233.60 us | 1.520 us | 1.422 us | 63.7207 |    195 KB |
    | NoGenerics |  12.92 us | 0.253 us | 0.362 us |  2.5635 |      8 KB |
    */
    [Benchmark]
    public int Generics()
    {
        int totalCount = _measurements.Length;

        var summedMeasurements = new List<int>(totalCount);
        for (int index = 0; index < totalCount; index++)
        {
            var subList = _measurements.Skip(index).Take(3);

            if (subList.Count() == 3)
                summedMeasurements.Add(subList.Sum());
        }

        int totalIncreases = 0;

        int prevValue = _measurements.First();

        foreach (var summedMeasurement in summedMeasurements.Skip(1))
        {
            if (prevValue < summedMeasurement) totalIncreases++;

            prevValue = summedMeasurement;
        }

        return totalIncreases;
    }

    [Benchmark]
    public int NoGenerics()
    {
        int totalCount = _measurements.Length;

        int totalIncreases = 0;

        var summedMeasurements = new List<int>(totalCount);
        for (int index = 0; index < totalCount; index++)
        {
            if ((index + GroupingSize) > _measurements.Length) break;

            var spannedMeasurements = 
                new Span<int>(_measurements, index, GroupingSize);

            int numberOfItemsInSpan = spannedMeasurements.Length;
            if (numberOfItemsInSpan != GroupingSize) break;

            int sum = 0;
            for (int spanIndex = 0; spanIndex < numberOfItemsInSpan; spanIndex++)
            {
                sum += spannedMeasurements[spanIndex];
            }
            summedMeasurements.Add(sum);
        }

        int? prevValue = null;
        var totalSummedCount = summedMeasurements.Count;
        for (int index = 0; index < totalSummedCount; index++)
        {
            if (!prevValue.HasValue)
            {
                // Set first
                prevValue = summedMeasurements[index];
                continue;
            }

            if (prevValue < summedMeasurements[index]) totalIncreases++;

            prevValue = summedMeasurements[index];
        }

        return totalIncreases;
    }
}
}
