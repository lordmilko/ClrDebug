using System;
using System.IO;
using System.Text;

namespace PEReader.PE
{
    public class PEBinaryReader : BinaryReader
    {
        public long Position => BaseStream.Position;

        public PEBinaryReader(Stream input) : base(input, Encoding.UTF8)
        {
        }

        public void Seek(int offset)
        {
            BaseStream.Seek(offset, SeekOrigin.Begin);
        }

        public Guid ReadGuid()
        {
            var bytes = ReadBytes(16);

            return new Guid(bytes);
        }

        /// <summary>
        /// Reads a fixed-length byte block as a null-padded UTF8-encoded string.
        /// The padding is not included in the returned string.
        ///
        /// Note that it is legal for UTF8 strings to contain NUL; if NUL occurs
        /// between non-NUL codepoints, it is not considered to be padding and
        /// is included in the result.
        /// </summary>
        public string ReadNullPaddedUTF8(int byteCount)
        {
            byte[] bytes = ReadBytes(byteCount);
            int nonPaddedLength = 0;
            for (int i = bytes.Length; i > 0; --i)
            {
                if (bytes[i - 1] != 0)
                {
                    nonPaddedLength = i;
                    break;
                }
            }
            return Encoding.UTF8.GetString(bytes, 0, nonPaddedLength);
        }

        //String may or may not be null terminated. If it is, we'll trim the trailing null
        public string ReadUnicodeString(int byteCount)
        {
            var builder = new StringBuilder();

            for (var i = 0; i < byteCount; i++)
                builder.Append((char)ReadUInt16());

            if (builder[builder.Length - 1] == '\0')
                builder.Length--;

            return builder.ToString();
        }

        public string ReadSZString()
        {
            var builder = new StringBuilder();

            while (true)
            {
                byte b = ReadByte();

                if (0 == b)
                    break;

                builder.Append((char)b);
            }

            return builder.ToString();
        }
    }
}
