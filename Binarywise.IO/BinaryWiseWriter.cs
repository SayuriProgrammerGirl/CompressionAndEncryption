namespace Binarywise.IO
{
    using System;
    using System.IO;

    public class BinarywiseWriter
    {
        private readonly BinaryWriter writer;

        private int bitsWrote;
        private byte numberToWrite;

        public BinarywiseWriter(Stream stream)
        {
            //Should I dispose this?
            this.writer = new BinaryWriter(stream);
            this.bitsWrote = 0;
            numberToWrite = 0;
        }

        public void WriteBit(bool bit)
        {
            numberToWrite = (byte)(numberToWrite << 1);
            if (bit)
            {
                numberToWrite = (byte)(numberToWrite | 0x1);
            }
            bitsWrote++;

            if (bitsWrote == 8)
            {
                writer.Write(numberToWrite);
                bitsWrote = 0;
                numberToWrite = 0;
            }
        }

        public void Close()
        {
            for (int i = bitsWrote; i < 8; i++)
            {
                WriteBit(false);
            }
        }
    }

    public class BinarywiseReader
    {
        private BinaryReader reader;
        private int bitsRead;
        private byte readValue;
        private bool endOfStream;

        public BinarywiseReader(Stream stream)
        {
            this.reader = new BinaryReader(stream);
            bitsRead = 0;
            readValue = reader.ReadByte();
            endOfStream = false;
        }

        public bool ReadBit()
        {
            byte temp = (byte) (readValue >> 7);
            bool bit = temp == 0x1;

            readValue = (byte) (readValue << 1);
            bitsRead++;
            if (bitsRead == 8)
            {
                if (EndOfStream())
                {
                    endOfStream = true;
                }
                else
                {
                    bitsRead = 0;
                    readValue = reader.ReadByte();
                }
                
            }

            return bit;
        }

        private bool EndOfStream()
        {
            return reader.BaseStream.Position == reader.BaseStream.Length;
        }

        public bool EOF()
        {
            return endOfStream;
        }
    }
}
