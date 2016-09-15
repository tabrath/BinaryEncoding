using System.Collections.Generic;
using System.Linq;

namespace BinaryEncoding
{
    public static partial class Binary
    {
        public static readonly EndianCodec BigEndian = new BigEndianCodec();
        public static readonly EndianCodec LittleEndian = new LittleEndianCodec();

        public static byte[] Concat(params byte[][] arrays)
        {
            IEnumerable<byte> result = new byte[0];
            foreach (var array in arrays)
                result = result.Concat(array);
            return result.ToArray();
        }

        public static int DecodeString(this byte[] buffer, int offset, EndianCodec codec, out string value)
        {
            var start = offset;

            var length = codec.GetInt32(buffer, offset);
            offset += 4;
            value = System.Text.Encoding.UTF8.GetString(buffer, offset, length);
            offset += length;

            return offset - start;
        }

        public static int EncodeString(this byte[] buffer, int offset, EndianCodec codec, string value)
        {
            var start = offset;

            var encoded = System.Text.Encoding.UTF8.GetBytes(value);
            offset += codec.Set(encoded.Length, buffer, offset);
            encoded.CopyTo(buffer, offset);
            offset += encoded.Length;

            return offset - start;
        }
    }

}
