namespace Day3
{
    public class BinaryNumber
    {
        public BinaryNumber(string value)
        {
            Value = value;
        }

        public string Value { get; }
        public int Length => Value.Length;
        public bool GetAtIndex(int index)
        {
            string stringAtIndex = Value.Substring(index, 1);
            return stringAtIndex == "1";
        }
    }
}
