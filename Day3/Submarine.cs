using System;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

namespace Day3
{
    public class Submarine
    {
        public static int Calculate_Task1(string[] inputs)
        {
            List<BinaryNumber> binaryInputs = inputs.Select(x => new BinaryNumber(x)).ToList();
            int maxLength = binaryInputs.First().Length;
            var mostCommonAtIndex = GetMostCommonValueAtIndexes(maxLength, binaryInputs);

            var gammaByte = GetByteRepresentation(false, mostCommonAtIndex);
            var gamma = Convert.ToInt32(gammaByte, 2);

            var epsilonByte = GetByteRepresentation(true, mostCommonAtIndex);
            var epsilon = Convert.ToInt32(epsilonByte, 2);

            return gamma * epsilon;
        }

        public static int Calculate_Task2(string[] inputs)
        {
            List<BinaryNumber> binaryInputs = inputs.Select(x => new BinaryNumber(x)).ToList();
            int maxLength = binaryInputs.First().Length;
            Dictionary<int, bool> mostCommonAtIndexes = GetMostCommonValueAtIndexes(maxLength, binaryInputs);

            var matchingValuesAtPosition = new Dictionary<int, List<string>>(inputs.Length);

            var oxygenList = inputs.Select(x => new BinaryNumber(x)).ToList();
            var oxygenResult = GetResultByBitCriteria(oxygenList, 0, maxLength, false);
            int oxygenGeneratorRating = Convert.ToInt32(oxygenResult.First().Value, 2);

            var co2ScrubberList = inputs.Select(x => new BinaryNumber(x)).ToList();
            var co2Result = GetResultByBitCriteria(co2ScrubberList, 0, maxLength, true);
            int co2ScubberRating = Convert.ToInt32(co2Result.First().Value, 2);

            return oxygenGeneratorRating * co2ScubberRating;
        }

        private static Dictionary<int, bool> GetMostCommonValueAtIndexes(int maxLength, List<BinaryNumber> binaryInputs)
        {
            var returnCollection = new Dictionary<int, bool>(binaryInputs.Count);

            for (int index = 0; index < maxLength; index++)
            {
                List<bool> allItemsAtPosition = binaryInputs.Select(x => x.GetAtIndex(index)).ToList();

                returnCollection.Add(index, allItemsAtPosition.MostCommon());
            }

            return returnCollection;
        }

        private static List<BinaryNumber> GetResultByBitCriteria(List<BinaryNumber> list, int currentIndex, int maxIndex, bool invertMostCommon)
        {
            if (currentIndex >= maxIndex || list.Count == 1) return list;

            List<bool> valuesForIndex = list.Select(x => x.GetAtIndex(currentIndex)).ToList();
            bool mostCommonBit = valuesForIndex.MostCommon();
            if (invertMostCommon)
                mostCommonBit = !mostCommonBit;

            List<string> valueResults = list.GetBinaryValuesWithMostCommonAtPosition(currentIndex, mostCommonBit);
            RemoveValuesNotInList(list, valueResults);

            return GetResultByBitCriteria(list, currentIndex += 1, maxIndex, invertMostCommon);
        }

        private static void RemoveValuesNotInList(List<BinaryNumber> sourceList, List<string> valuesToKeep)
        {
            for (int i = sourceList.Count; i-- > 0;)
            {
                if (valuesToKeep.Contains(sourceList[i].Value) == false)
                    sourceList.RemoveAt(i);
            }
        }

        public static string GetByteRepresentation(bool invert, Dictionary<int, bool> mostCommonAtIndex)
        {
            var sb = new StringBuilder();
            foreach (var mostCommon in mostCommonAtIndex)
            {
                if (invert)
                    sb.Append((!mostCommon.Value).ToBit());
                else
                    sb.Append(mostCommon.Value.ToBit());
            }

            return sb.ToString();
        }
    }
}
