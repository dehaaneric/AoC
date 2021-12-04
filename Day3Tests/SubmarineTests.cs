using Day3;
using System.Collections.Generic;
using Xunit;

namespace Day3Tests
{
    public class SubmarineTests
    {
        List<string> inputs;
        public SubmarineTests()
        {
            SetInputs();
        }

        private void SetInputs()
        {
            inputs = new List<string>();
            inputs.Add("00100");
            inputs.Add("11110");
            inputs.Add("10110");
            inputs.Add("10111");
            inputs.Add("10101");
            inputs.Add("01111");
            inputs.Add("00111");
            inputs.Add("11100");
            inputs.Add("10000");
            inputs.Add("11001");
            inputs.Add("00010");
            inputs.Add("01010");
        }

        [Fact]
        public void Calculate_Task1_HasExpectedOutput()
        {
            int outcome = Submarine.Calculate_Task1(inputs.ToArray());

            Assert.Equal(198, outcome);
        }

        [Fact]
        public void Calculate_Task2_HasExpectedOutput()
        {
            int outcome = Submarine.Calculate_Task2(inputs.ToArray());

            Assert.Equal(230, outcome);
        }

    }

}