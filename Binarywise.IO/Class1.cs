namespace Binarywise.IO
{
    public class Class1
    {
        private int test = 1;
    }

    internal enum Bit
    {
        Zero,
        One
    }

    internal class BitExtractor
    {
        private readonly byte value;

        public BitExtractor(byte value)
        {
            this.value = value;
        }

        public Bit GetValueForBit(int position)
        {
            int extractedBit = (value >> position) & 0x1;
            Bit bit = extractedBit == 0 ? Bit.Zero : Bit.One;
            return bit;
        }
    }
}
