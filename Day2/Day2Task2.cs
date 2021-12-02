using BenchmarkDotNet.Attributes;

namespace Day2
{
    [MemoryDiagnoser]
    public class Day2Task2
    {
        string[] _input;
        public Day2Task2()
        {
            _input = System.IO.File.ReadAllLines(@"day2input.txt");
        }

        [Benchmark]
        public int CalculateOO()
        {
            var linesCount = _input.Length;

            var movements = new List<Movement>(linesCount);
            foreach (var line in _input)
            {
                string[] parts = line.Split(' ');
                movements.Add(new Movement(parts[0], int.Parse(parts[1])));
            }

            var location = Location.Start;
            foreach (var movement in movements)
            {
                location = location.Move(movement);
            }

            int finalHorizontal = location.Position;
            int finalDepth = location.Depth;
            int total = finalDepth * finalHorizontal;

            return total;
        }

        [Benchmark]
        public int CalculateFunctional()
        {
            var lineCount = _input.Length;
            var movements = new List<Tuple<string, int>>(lineCount);
            foreach (var line in _input)
            {
                var parts = line.Split(' ');
                movements.Add(new Tuple<string, int>(parts[0], int.Parse(parts[1])));
            }

            int aim = 0, position = 0, depth = 0;

            foreach (var movement in movements)
            {
                if (movement.Item1 == "forward")
                {
                    position += movement.Item2;
                    depth += movement.Item2 * aim;
                }
                else if(movement.Item1 == "up")
                {
                    aim -= movement.Item2;
                }
                else if (movement.Item1 == "down")
                {
                    aim += movement.Item2;
                }
            }

            return depth * position;
        }

        class Location
        {
            public Location(int position, int depth, int aim)
            {
                Position = position;
                Depth = depth;
                Aim = aim;
            }

            public int Position { get; }
            public int Depth { get; }
            public int Aim { get; }

            public Location Move(Movement movement)
            {
                switch (movement.Action)
                {
                    case Movements.Forward:
                        {
                            return new Location(Position + movement.Value, Depth + (Aim * movement.Value), Aim);
                        }
                    case Movements.Up:
                        {
                            return new Location(Position, Depth, Aim - movement.Value);
                        }
                    case Movements.Down:
                        {
                            return new Location(Position, Depth, Aim + movement.Value);
                        }
                    default:
                        throw new ArgumentException($"Not implemented action of {movement.Action}");
                }
            }

            public static Location Start => new Location(0, 0, 0);
        }

        struct Movement
        {
            public Movement(string action, int value)
            {
                Action = action;
                Value = value;
            }
            public string Action { get; }
            public int Value { get; }
        }

        class Movements
        {
            public const string Forward = "forward";
            public const string Up = "up";
            public const string Down = "down";
        }
    }
}
