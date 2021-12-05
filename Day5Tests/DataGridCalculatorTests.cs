using Day5;
using Day5.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace Day5Tests
{
    public class DataGridCalculatorTests
    {
        [Fact]
        public void DataGridCalculator_Calculate_HasExpectedOutput()
        {
            List<DataLineCoord> dataPoints = CreateDataPoints();

            var calculator = new DataGridCalculator();
            int output = calculator.Calculate(dataPoints);

            Assert.Equal(5, output);
        }

        private List<DataLineCoord> CreateDataPoints()
        {
            /*
                0,9 -> 5,9
                8,0 -> 0,8
                9,4 -> 3,4
                2,2 -> 2,1
                7,0 -> 7,4
                6,4 -> 2,0
                0,9 -> 2,9
                3,4 -> 1,4
                0,0 -> 8,8
                5,5 -> 8,2
             */

            var dataPoints = new List<DataLineCoord>(10);

            dataPoints.Add(new DataLineCoord(new Coord(0, 9), new Coord(5, 9)));
            dataPoints.Add(new DataLineCoord(new Coord(8, 0), new Coord(0, 8)));
            dataPoints.Add(new DataLineCoord(new Coord(9, 4), new Coord(3, 4)));
            dataPoints.Add(new DataLineCoord(new Coord(2, 2), new Coord(2, 1)));
            dataPoints.Add(new DataLineCoord(new Coord(7, 0), new Coord(7, 4)));
            dataPoints.Add(new DataLineCoord(new Coord(6, 4), new Coord(2, 0)));
            dataPoints.Add(new DataLineCoord(new Coord(0, 9), new Coord(2, 9)));
            dataPoints.Add(new DataLineCoord(new Coord(3, 4), new Coord(1, 4)));
            dataPoints.Add(new DataLineCoord(new Coord(0, 0), new Coord(8, 8)));
            dataPoints.Add(new DataLineCoord(new Coord(5, 5), new Coord(8, 2)));

            return dataPoints;
        }
    }
}