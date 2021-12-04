namespace Day3
{
    public static class ExtensionHelpers
    {
        public static int ToBit(this bool value)
        {
            return value ? 1 : 0;
        }
        public static T MostCommon<T>(this IEnumerable<T> list)
        {
            var most = list
                    .GroupBy(i => i)
                    .OrderByDescending(grp => grp.Count())
                    .ThenByDescending(x => x.Key)
                    .Select(grp => grp.Key)
                    .First();

            return most;
        }

        public static List<string> GetBinaryValuesWithMostCommonAtPosition(this List<BinaryNumber> binaryInputs, int index, bool bitValue)
        {
            var returnList = new List<string>(binaryInputs.Count);
            foreach (var input in binaryInputs)
            {
                if (input.GetAtIndex(index) == bitValue)
                    returnList.Add(input.Value);
            }

            return returnList;
        }
    }
}
