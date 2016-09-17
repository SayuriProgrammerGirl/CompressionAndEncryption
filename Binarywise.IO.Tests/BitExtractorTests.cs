using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Binarywise.IO.Tests
{
    [TestClass]
    public class BitExtractorTests
    {
        BitExtractor extractor;

        public void SetUp(byte value)
        {
            extractor = new BitExtractor(value);
        }

        [TestMethod]
        public void TestMethod1()
        {
            byte value = 0xAA;
            Bit[] bits =
            {
                Bit.Zero, Bit.One, Bit.Zero, Bit.One,
                Bit.Zero, Bit.One, Bit.Zero, Bit.One,
            };

            SetUp(value);

            for (int i = 0; i < 8; i++)
            {
                Bit bit = extractor.GetValueForBit(i);
                Assert.AreEqual(bit,bits[i]);
            }
        }
    }
}
