using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Binarywise.IO.Tests
{
    [TestClass]
    public class Usage
    {
        [TestMethod]
        public void WriterUsage()
        {
            bool[] booleans = new[] { true, false, true, false, true, false, true, false };

            using (var mem = new MemoryStream())
            {
                var v = new BinarywiseWriter(mem);

                foreach (var bit in booleans)
                {
                    v.WriteBit(bit);
                }

                mem.Position = 0;

                byte[] result = new byte[10];
                mem.Read(result, 0, 2);
                int x = 0;
            }
        }

        public void ReaderUsage()
        {

        }

        [TestMethod]
        public void CompleteTest()
        {
            using (Stream reader = File.OpenRead("..\\..\\Resources\\Lelouch.jpg"))
            using (Stream writer = File.Create("..\\..\\Resources\\LelouchTest.jpg"))
            {
                var r = new BinarywiseReader(reader);
                var w = new BinarywiseWriter(writer);

                while (!r.EOF())
                {
                    bool readValue = r.ReadBit();
                    w.WriteBit(readValue);
                }

                w.Close();
            }
        }
    }
}
