using BenchmarkDotNet.Attributes;
using Day5.Models;
using System.Collections.Generic;

namespace Day5
{
    [MemoryDiagnoser]
    public class DataGridCalculator
    {
        Dictionary<Coord, int> coordinateGrid = new Dictionary<Coord, int>();
        
        List<DataLineCoord> _dataLineCoords;
        public DataGridCalculator()
        {
            string[] input = File.ReadAllLines(@"Day5Input.txt");

            _dataLineCoords = new List<DataLineCoord>(input.Length);

            foreach (var line in input)
            {
                // 580,438 -> 580,817
                int index = line.IndexOf('-');
                string leftPart = line.Substring(0, index).Trim();
                string rightPart = line.Substring(index + 2).Trim();

                var coord1 = MakeCoord(leftPart);
                var coord2 = MakeCoord(rightPart);

                if (coord1.X == coord2.X || coord1.Y == coord2.Y)
                    _dataLineCoords.Add(new DataLineCoord(coord1, coord2));
            }
        }

        Coord MakeCoord(string number)
        {
            string[] items = number.Split(',');
            return new Coord(int.Parse(items[0]), int.Parse(items[1]));
        }

        [Benchmark]
        public int Calculate()
        {
            var coordCount = _dataLineCoords.Count;
            for (int index = 0; index < coordCount; index++)
            {
                DataLineCoord line = _dataLineCoords[index];
                if(line.Point1.X == line.Point2.X || line.Point1.Y == line.Point2.Y)
                {
                    List<Coord> coordinateSteps = GetCoordinateStepsBetweenPoints(line);

                    AddCoordinatesToGrid(coordinateSteps);
                }
            }

            return coordinateGrid.Where(x => x.Value >= 2).Count();
        }

        public int Calculate(List<DataLineCoord> dataLineCoords)
        {
            _dataLineCoords = dataLineCoords;
            return Calculate();
        }

        private void AddCoordinatesToGrid(List<Coord> coordinates)
        {
            int length = coordinates.Count;
            for (int index = 0; index < length; index++)
            {
                var coord = coordinates[index];

                if (coordinateGrid.TryGetValue(coord, out int currentCount))
                {
                    coordinateGrid[coord] = currentCount + 1;
                }
                else
                {
                    coordinateGrid.Add(coord, 1);
                }
            }
        }

        private List<Coord> GetCoordinateStepsBetweenPoints(DataLineCoord line)
        {
            // x,y
            var dataPoint1 = line.Point1;   // 0,9
            var dataPoint2 = line.Point2;   // 5,9

            if (dataPoint1.X == dataPoint2.X)
            {
                var X = dataPoint1.X;
                var y1 = dataPoint1.Y;
                var y2 = dataPoint2.Y;

                var numberOfPositionPointsBetween = Math.Abs(y1 - y2);
                var returnList = new List<Coord>(numberOfPositionPointsBetween);

                for (int index = 0; index <= numberOfPositionPointsBetween; index++)
                {
                    int? yPos = null;
                    if (y1 > y2) // 5 & 0
                        yPos = y2 + index;
                    else if (y2 > y1)
                        yPos = y1 + index;

                    if (yPos.HasValue)
                        returnList.Add(new Coord(X, yPos.Value));
                }
                return returnList;
            }
            else if (dataPoint1.Y == dataPoint2.Y)
            {
                var y = dataPoint1.Y;
                var x1 = dataPoint1.X;
                var x2 = dataPoint2.X;

                var numberOfPositionPointsBetween = Math.Abs(x1 - x2);
                var returnList = new List<Coord>(numberOfPositionPointsBetween);

                for (int index = 0; index <= numberOfPositionPointsBetween; index++)
                {
                    int? xPos = null;
                    if (x1 > x2) // 5 & 0
                        xPos = x2 + index;
                    else if (x2 > x1)
                        xPos = x1 + index;

                    if (xPos.HasValue)
                        returnList.Add(new Coord(xPos.Value, y));
                }
                return returnList;
            }

            return null;
        }
    }
}
