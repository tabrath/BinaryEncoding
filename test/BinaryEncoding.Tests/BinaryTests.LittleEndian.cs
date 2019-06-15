using System;
using Xunit;

namespace BinaryEncoding.Tests
{
    public partial class BinaryTests
    {
        [Theory]
        [InlineData(new byte[] { 0x00, 0x80 }, short.MinValue)]
        [InlineData(new byte[] { 0xff, 0x7f }, short.MaxValue)]
        [InlineData(new byte[] { 0xff, 0x3f }, short.MaxValue / 2)]
        public void LittleEndian_GetInt16(byte[] bytes, int expected)
        {
            var decoded = Binary.LittleEndian.GetInt16(bytes, 0);

            Assert.Equal(expected, decoded);
        }
        [Theory]
        [InlineData(new byte[] { 0x00, 0x80 }, short.MinValue)]
        [InlineData(new byte[] { 0xff, 0x7f }, short.MaxValue)]
        [InlineData(new byte[] { 0xff, 0x3f }, short.MaxValue / 2)]
        public void LittleEndian_GetInt16_Span(byte[] bytes, int expected)
        {
            var decoded = Binary.LittleEndian.GetInt16(bytes.AsSpan());

            Assert.Equal(expected, decoded);
        }

        [Theory]
        [InlineData(new byte[] { 0x00, 0x00 }, ushort.MinValue)]
        [InlineData(new byte[] { 0xff, 0xff }, ushort.MaxValue)]
        [InlineData(new byte[] { 0xff, 0x7f }, ushort.MaxValue / 2)]
        public void LittleEndian_GetUInt16(byte[] bytes, uint expected)
        {
            var decoded = Binary.LittleEndian.GetUInt16(bytes, 0);

            Assert.Equal(expected, decoded);
        }

        [Theory]
        [InlineData(new byte[] { 0x00, 0x00 }, ushort.MinValue)]
        [InlineData(new byte[] { 0xff, 0xff }, ushort.MaxValue)]
        [InlineData(new byte[] { 0xff, 0x7f }, ushort.MaxValue / 2)]
        public void LittleEndian_GetUInt16_Span(byte[] bytes, uint expected)
        {
            var decoded = Binary.LittleEndian.GetUInt16(bytes.AsSpan());

            Assert.Equal(expected, decoded);
        }

        [Theory]
        [InlineData(new byte[] { 0x00, 0x00, 0x00, 0x80 }, int.MinValue)]
        [InlineData(new byte[] { 0xff, 0xff, 0xff, 0x7f }, int.MaxValue)]
        public void LittleEndian_GetInt32(byte[] bytes, int expected)
        {
            var decoded = Binary.LittleEndian.GetInt32(bytes, 0);

            Assert.Equal(expected, decoded);
        }

        [Theory]
        [InlineData(new byte[] { 0x00, 0x00, 0x00, 0x80 }, int.MinValue)]
        [InlineData(new byte[] { 0xff, 0xff, 0xff, 0x7f }, int.MaxValue)]
        public void LittleEndian_GetInt32_Span(byte[] bytes, int expected)
        {
            var decoded = Binary.LittleEndian.GetInt32(bytes.AsSpan());

            Assert.Equal(expected, decoded);
        }

        [Theory]
        [InlineData(new byte[] { 0x00, 0x00, 0x00, 0x00 }, uint.MinValue)]
        [InlineData(new byte[] { 0xff, 0xff, 0xff, 0xff }, uint.MaxValue)]
        public void LittleEndian_GetUInt32(byte[] bytes, uint expected)
        {
            var decoded = Binary.LittleEndian.GetUInt32(bytes, 0);

            Assert.Equal(expected, decoded);
        }

        [Theory]
        [InlineData(new byte[] { 0x00, 0x00, 0x00, 0x00 }, uint.MinValue)]
        [InlineData(new byte[] { 0xff, 0xff, 0xff, 0xff }, uint.MaxValue)]
        public void LittleEndian_GetUInt32_Span(byte[] bytes, uint expected)
        {
            var decoded = Binary.LittleEndian.GetUInt32(bytes.AsSpan());

            Assert.Equal(expected, decoded);
        }

        [Theory]
        [InlineData(new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x80 }, long.MinValue)]
        [InlineData(new byte[] { 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0x7f }, long.MaxValue)]
        public void LittleEndian_GetInt64(byte[] bytes, long expected)
        {
            var decoded = Binary.LittleEndian.GetInt64(bytes, 0);

            Assert.Equal(expected, decoded);
        }

        [Theory]
        [InlineData(new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x80 }, long.MinValue)]
        [InlineData(new byte[] { 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0x7f }, long.MaxValue)]
        public void LittleEndian_GetInt64_Span(byte[] bytes, long expected)
        {
            var decoded = Binary.LittleEndian.GetInt64(bytes.AsSpan());

            Assert.Equal(expected, decoded);
        }

        [Theory]
        [InlineData(new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }, ulong.MinValue)]
        [InlineData(new byte[] { 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff }, ulong.MaxValue)]
        public void LittleEndian_GetUInt64(byte[] bytes, ulong expected)
        {
            var decoded = Binary.LittleEndian.GetUInt64(bytes, 0);

            Assert.Equal(expected, decoded);
        }

        [Theory]
        [InlineData(new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }, ulong.MinValue)]
        [InlineData(new byte[] { 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff }, ulong.MaxValue)]
        public void LittleEndian_GetUInt64_Span(byte[] bytes, ulong expected)
        {
            var decoded = Binary.LittleEndian.GetUInt64(bytes.AsSpan());

            Assert.Equal(expected, decoded);
        }

        [Theory]
        [InlineData(new byte[] { 0x00, 0x80 }, short.MinValue)]
        [InlineData(new byte[] { 0xff, 0x7f }, short.MaxValue)]
        public void LittleEndian_Set_Int16(byte[] expected, short n)
        {
            var b = new byte[2];

            Binary.LittleEndian.Set(n, b, 0);

            Assert.Equal(b, expected);
        }

        [Theory]
        [InlineData(new byte[] { 0x00, 0x80 }, short.MinValue)]
        [InlineData(new byte[] { 0xff, 0x7f }, short.MaxValue)]
        public void LittleEndian_Set_Int16_Span(byte[] expected, short n)
        {
            var b = new byte[2];

            Binary.LittleEndian.Set(n, b.AsSpan());

            Assert.Equal(b, expected);
        }

        [Theory]
        [InlineData(new byte[] { 0x00, 0x00 }, ushort.MinValue)]
        [InlineData(new byte[] { 0xff, 0xff }, ushort.MaxValue)]
        public void LittleEndian_Set_UInt16(byte[] expected, ushort n)
        {
            var b = new byte[2];

            Binary.LittleEndian.Set(n, b, 0);

            Assert.Equal(b, expected);
        }

        [Theory]
        [InlineData(new byte[] { 0x00, 0x00 }, ushort.MinValue)]
        [InlineData(new byte[] { 0xff, 0xff }, ushort.MaxValue)]
        public void LittleEndian_Set_UInt16_Span(byte[] expected, ushort n)
        {
            var b = new byte[2];

            Binary.LittleEndian.Set(n, b.AsSpan());

            Assert.Equal(b, expected);
        }

        [Theory]
        [InlineData(new byte[] { 0x00, 0x00, 0x00, 0x80 }, int.MinValue)]
        [InlineData(new byte[] { 0xff, 0xff, 0xff, 0x7f }, int.MaxValue)]
        public void LittleEndian_Set_Int32(byte[] expected, int n)
        {
            var b = new byte[4];

            Binary.LittleEndian.Set(n, b, 0);

            Assert.Equal(b, expected);
        }

        [Theory]
        [InlineData(new byte[] { 0x00, 0x00, 0x00, 0x80 }, int.MinValue)]
        [InlineData(new byte[] { 0xff, 0xff, 0xff, 0x7f }, int.MaxValue)]
        public void LittleEndian_Set_Int32_Span(byte[] expected, int n)
        {
            var b = new byte[4];

            Binary.LittleEndian.Set(n, b.AsSpan());

            Assert.Equal(b, expected);
        }

        [Theory]
        [InlineData(new byte[] { 0x00, 0x00, 0x00, 0x00 }, uint.MinValue)]
        [InlineData(new byte[] { 0xff, 0xff, 0xff, 0xff }, uint.MaxValue)]
        public void LittleEndian_Set_UInt32(byte[] expected, uint n)
        {
            var b = new byte[4];

            Binary.LittleEndian.Set(n, b, 0);

            Assert.Equal(b, expected);
        }

        [Theory]
        [InlineData(new byte[] { 0x00, 0x00, 0x00, 0x00 }, uint.MinValue)]
        [InlineData(new byte[] { 0xff, 0xff, 0xff, 0xff }, uint.MaxValue)]
        public void LittleEndian_Set_UInt32_Span(byte[] expected, uint n)
        {
            var b = new byte[4];

            Binary.LittleEndian.Set(n, b.AsSpan());

            Assert.Equal(b, expected);
        }

        [Theory]
        [InlineData(new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x80 }, long.MinValue)]
        [InlineData(new byte[] { 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0x7f }, long.MaxValue)]
        public void LittleEndian_Set_Int64(byte[] expected, long n)
        {
            var b = new byte[8];

            Binary.LittleEndian.Set(n, b, 0);

            Assert.Equal(b, expected);
        }

        [Theory]
        [InlineData(new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x80 }, long.MinValue)]
        [InlineData(new byte[] { 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0x7f }, long.MaxValue)]
        public void LittleEndian_Set_Int64_Span(byte[] expected, long n)
        {
            var b = new byte[8];

            Binary.LittleEndian.Set(n, b.AsSpan());

            Assert.Equal(b, expected);
        }

        [Theory]
        [InlineData(new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }, ulong.MinValue)]
        [InlineData(new byte[] { 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff }, ulong.MaxValue)]
        public void LittleEndian_Set_UInt64(byte[] expected, ulong n)
        {
            var b = new byte[8];

            Binary.LittleEndian.Set(n, b, 0);

            Assert.Equal(b, expected);
        }

        [Theory]
        [InlineData(new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }, ulong.MinValue)]
        [InlineData(new byte[] { 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff }, ulong.MaxValue)]
        public void LittleEndian_Set_UInt64_Span(byte[] expected, ulong n)
        {
            var b = new byte[8];

            Binary.LittleEndian.Set(n, b.AsSpan());

            Assert.Equal(b, expected);
        }
    }
}

