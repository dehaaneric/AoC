using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5.Models
{
    public class DataLineCoord
    {
        public DataLineCoord(Coord point1, Coord point2)
        {
            Point1 = point1;
            Point2 = point2;
        }

        public Coord Point1 { get; }
        public Coord Point2 { get; }
    }
    public class DataLine
    {
        public static DataLine Create(DataPoint d1, DataPoint d2) => new DataLine(d1, d2);

        public DataLine(DataPoint d1, DataPoint d2)
        {
            D1 = d1;
            D2 = d2;
        }

        public DataPoint D1 { get; }
        public DataPoint D2 { get; }

        public bool IsStraightLine
        {
            get
            {
                return D1.X == D2.X || D1.Y == D2.Y;
            }
        }
    }
    public class DataPointCounter : DataPoint
    {
        private int _counter;
        public DataPointCounter(int x, int y) : base(x, y)
        {
            _counter = 0;
        }

        public void IncreaseCounter(int amount = 1)
        {
            _counter += amount;
        }

        public bool HasAtLeastNumberOfPoints(int numberOfPoints) => _counter >= numberOfPoints;
    }

    public class DataPoint
    {
        public DataPoint(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; }
        public int Y { get; }
    }
}
