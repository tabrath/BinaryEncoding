using System;
using Xunit;

namespace BinaryEncoding.Tests
{
    public partial class BinaryTests
    {
        [Theory]
        [InlineData(new byte[] { 0x80, 0x00 }, short.MinValue)]
        [InlineData(new byte[] { 0x7f, 0xff }, short.MaxValue)]
        [InlineData(new byte[] { 0x3f, 0xff }, short.MaxValue / 2)]
        public void BigEndian_GetInt16(byte[] bytes, int expected)
        {
            var decoded = Binary.BigEndian.GetInt16(bytes, 0);

            Assert.Equal(expected, decoded);
        }
        [Theory]
        [InlineData(new byte[] { 0x80, 0x00 }, short.MinValue)]
        [InlineData(new byte[] { 0x7f, 0xff }, short.MaxValue)]
        [InlineData(new byte[] { 0x3f, 0xff }, short.MaxValue / 2)]
        public void BigEndian_GetInt16_Span(byte[] bytes, int expected)
        {
            var decoded = Binary.BigEndian.GetInt16(bytes.AsSpan());

            Assert.Equal(expected, decoded);
        }

        [Theory]
        [InlineData(new byte[] { 0x00, 0x00 }, ushort.MinValue)]
        [InlineData(new byte[] { 0xff, 0xff }, ushort.MaxValue)]
        [InlineData(new byte[] { 0x7f, 0xff }, ushort.MaxValue / 2)]
        public void BigEndian_GetUInt16(byte[] bytes, uint expected)
        {
            var decoded = Binary.BigEndian.GetUInt16(bytes, 0);

            Assert.Equal(expected, decoded);
        }

        [Theory]
        [InlineData(new byte[] { 0x00, 0x00 }, ushort.MinValue)]
        [InlineData(new byte[] { 0xff, 0xff }, ushort.MaxValue)]
        [InlineData(new byte[] { 0x7f, 0xff }, ushort.MaxValue / 2)]
        public void BigEndian_GetUInt16_Span(byte[] bytes, uint expected)
        {
            var decoded = Binary.BigEndian.GetUInt16(bytes.AsSpan());

            Assert.Equal(expected, decoded);
        }

        [Theory]
        [InlineData(new byte[] { 0x00, 0x00, 0x04, 0x00 }, 1024)]
        [InlineData(new byte[] { 0x00, 0x00, 0x08, 0x00 }, 2048)]
        [InlineData(new byte[] { 0x00, 0x00, 0x10, 0x00 }, 4096)]
        [InlineData(new byte[] { 0x00, 0x00, 0x20, 0x00 }, 8192)]
        [InlineData(new byte[] { 0x00, 0x10, 0x00, 0x00 }, 1048576)]
        [InlineData(new byte[] { 0x00, 0xa0, 0x00, 0x00 }, 10485760)]
        [InlineData(new byte[] { 0x06, 0x3f, 0xff, 0xd8 }, 104857560)]
        [InlineData(new byte[] { 0x7f, 0xff, 0xff, 0xff }, int.MaxValue)]
        public void BigEndian_GetInt32(byte[] bytes, int expected)
        {
            var decoded = Binary.BigEndian.GetInt32(bytes, 0);

            Assert.Equal(expected, decoded);
        }

        [Theory]
        [InlineData(new byte[] { 0x00, 0x00, 0x04, 0x00 }, 1024)]
        [InlineData(new byte[] { 0x00, 0x00, 0x08, 0x00 }, 2048)]
        [InlineData(new byte[] { 0x00, 0x00, 0x10, 0x00 }, 4096)]
        [InlineData(new byte[] { 0x00, 0x00, 0x20, 0x00 }, 8192)]
        [InlineData(new byte[] { 0x00, 0x10, 0x00, 0x00 }, 1048576)]
        [InlineData(new byte[] { 0x00, 0xa0, 0x00, 0x00 }, 10485760)]
        [InlineData(new byte[] { 0x06, 0x3f, 0xff, 0xd8 }, 104857560)]
        [InlineData(new byte[] { 0x7f, 0xff, 0xff, 0xff }, int.MaxValue)]
        public void BigEndian_GetInt32_Span(byte[] bytes, int expected)
        {
            var decoded = Binary.BigEndian.GetInt32(bytes.AsSpan());

            Assert.Equal(expected, decoded);
        }

        [Theory]
        [InlineData(new byte[] { 0x00, 0x00, 0x04, 0x00 }, (uint)1024)]
        [InlineData(new byte[] { 0x00, 0x00, 0x08, 0x00 }, (uint)2048)]
        [InlineData(new byte[] { 0x00, 0x00, 0x10, 0x00 }, (uint)4096)]
        [InlineData(new byte[] { 0x00, 0x00, 0x20, 0x00 }, (uint)8192)]
        [InlineData(new byte[] { 0x00, 0x10, 0x00, 0x00 }, (uint)1048576)]
        [InlineData(new byte[] { 0x00, 0xa0, 0x00, 0x00 }, (uint)10485760)]
        [InlineData(new byte[] { 0x06, 0x3f, 0xff, 0xd8 }, (uint)104857560)]
        [InlineData(new byte[] { 0xff, 0xff, 0xff, 0xff }, uint.MaxValue)]
        public void BigEndian_GetUInt32(byte[] bytes, uint expected)
        {
            var decoded = Binary.BigEndian.GetUInt32(bytes, 0);

            Assert.Equal(expected, decoded);
        }

        [Theory]
        [InlineData(new byte[] { 0x00, 0x00, 0x04, 0x00 }, (uint)1024)]
        [InlineData(new byte[] { 0x00, 0x00, 0x08, 0x00 }, (uint)2048)]
        [InlineData(new byte[] { 0x00, 0x00, 0x10, 0x00 }, (uint)4096)]
        [InlineData(new byte[] { 0x00, 0x00, 0x20, 0x00 }, (uint)8192)]
        [InlineData(new byte[] { 0x00, 0x10, 0x00, 0x00 }, (uint)1048576)]
        [InlineData(new byte[] { 0x00, 0xa0, 0x00, 0x00 }, (uint)10485760)]
        [InlineData(new byte[] { 0x06, 0x3f, 0xff, 0xd8 }, (uint)104857560)]
        [InlineData(new byte[] { 0xff, 0xff, 0xff, 0xff }, uint.MaxValue)]
        public void BigEndian_GetUInt32_Span(byte[] bytes, uint expected)
        {
            var decoded = Binary.BigEndian.GetUInt32(bytes.AsSpan());

            Assert.Equal(expected, decoded);
        }

        [Theory]
        [InlineData(new byte[] { 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }, long.MinValue)]
        [InlineData(new byte[] { 0x7f, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff }, long.MaxValue)]
        public void BigEndian_GetInt64(byte[] bytes, long expected)
        {
            var decoded = Binary.BigEndian.GetInt64(bytes, 0);

            Assert.Equal(expected, decoded);
        }

        [Theory]
        [InlineData(new byte[] { 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }, long.MinValue)]
        [InlineData(new byte[] { 0x7f, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff }, long.MaxValue)]
        public void BigEndian_GetInt64_Span(byte[] bytes, long expected)
        {
            var decoded = Binary.BigEndian.GetInt64(bytes.AsSpan());

            Assert.Equal(expected, decoded);
        }

        [Theory]
        [InlineData(new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }, ulong.MinValue)]
        [InlineData(new byte[] { 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff }, ulong.MaxValue)]
        public void BigEndian_GetUInt64(byte[] bytes, ulong expected)
        {
            var decoded = Binary.BigEndian.GetUInt64(bytes, 0);

            Assert.Equal(expected, decoded);
        }

        [Theory]
        [InlineData(new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }, ulong.MinValue)]
        [InlineData(new byte[] { 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff }, ulong.MaxValue)]
        public void BigEndian_GetUInt64_Span(byte[] bytes, ulong expected)
        {
            var decoded = Binary.BigEndian.GetUInt64(bytes.AsSpan());

            Assert.Equal(expected, decoded);
        }

        [Theory]
        [InlineData(new byte[] { 0x80, 0x00 }, short.MinValue)]
        [InlineData(new byte[] { 0x7f, 0xff }, short.MaxValue)]
        public void BigEndian_Set_Int16(byte[] expected, short n)
        {
            var b = new byte[2];

            Binary.BigEndian.Set(n, b, 0);

            Assert.Equal(b, expected);
        }

        [Theory]
        [InlineData(new byte[] { 0x80, 0x00 }, short.MinValue)]
        [InlineData(new byte[] { 0x7f, 0xff }, short.MaxValue)]
        public void BigEndian_Set_Int16_Span(byte[] expected, short n)
        {
            var b = new byte[2];

            Binary.BigEndian.Set(n, b.AsSpan());

            Assert.Equal(b, expected);
        }

        [Theory]
        [InlineData(new byte[] { 0x00, 0x00 }, ushort.MinValue)]
        [InlineData(new byte[] { 0xff, 0xff }, ushort.MaxValue)]
        public void BigEndian_Set_UInt16(byte[] expected, ushort n)
        {
            var b = new byte[2];

            Binary.BigEndian.Set(n, b, 0);

            Assert.Equal(b, expected);
        }

        [Theory]
        [InlineData(new byte[] { 0x00, 0x00 }, ushort.MinValue)]
        [InlineData(new byte[] { 0xff, 0xff }, ushort.MaxValue)]
        public void BigEndian_Set_UInt16_Span(byte[] expected, ushort n)
        {
            var b = new byte[2];

            Binary.BigEndian.Set(n, b.AsSpan());

            Assert.Equal(b, expected);
        }

        [Theory]
        [InlineData(new byte[] { 0x00, 0x00, 0x04, 0x00 }, 1024)]
        [InlineData(new byte[] { 0x00, 0x00, 0x08, 0x00 }, 2048)]
        [InlineData(new byte[] { 0x00, 0x00, 0x10, 0x00 }, 4096)]
        [InlineData(new byte[] { 0x00, 0x00, 0x20, 0x00 }, 8192)]
        [InlineData(new byte[] { 0x00, 0x10, 0x00, 0x00 }, 1048576)]
        [InlineData(new byte[] { 0x00, 0xa0, 0x00, 0x00 }, 10485760)]
        [InlineData(new byte[] { 0x06, 0x3f, 0xff, 0xd8 }, 104857560)]
        [InlineData(new byte[] { 0x7f, 0xff, 0xff, 0xff }, int.MaxValue)]
        public void BigEndian_Set_Int32(byte[] expected, int n)
        {
            var b = new byte[4];

            Binary.BigEndian.Set(n, b, 0);

            Assert.Equal(b, expected);
        }

        [Theory]
        [InlineData(new byte[] { 0x00, 0x00, 0x04, 0x00 }, 1024)]
        [InlineData(new byte[] { 0x00, 0x00, 0x08, 0x00 }, 2048)]
        [InlineData(new byte[] { 0x00, 0x00, 0x10, 0x00 }, 4096)]
        [InlineData(new byte[] { 0x00, 0x00, 0x20, 0x00 }, 8192)]
        [InlineData(new byte[] { 0x00, 0x10, 0x00, 0x00 }, 1048576)]
        [InlineData(new byte[] { 0x00, 0xa0, 0x00, 0x00 }, 10485760)]
        [InlineData(new byte[] { 0x06, 0x3f, 0xff, 0xd8 }, 104857560)]
        [InlineData(new byte[] { 0x7f, 0xff, 0xff, 0xff }, int.MaxValue)]
        public void BigEndian_Set_Int32_Span(byte[] expected, int n)
        {
            var b = new byte[4];

            Binary.BigEndian.Set(n, b.AsSpan());

            Assert.Equal(b, expected);
        }

        [Theory]
        [InlineData(new byte[] { 0x00, 0x00, 0x04, 0x00 }, (uint)1024)]
        [InlineData(new byte[] { 0x00, 0x00, 0x08, 0x00 }, (uint)2048)]
        [InlineData(new byte[] { 0x00, 0x00, 0x10, 0x00 }, (uint)4096)]
        [InlineData(new byte[] { 0x00, 0x00, 0x20, 0x00 }, (uint)8192)]
        [InlineData(new byte[] { 0x00, 0x10, 0x00, 0x00 }, (uint)1048576)]
        [InlineData(new byte[] { 0x00, 0xa0, 0x00, 0x00 }, (uint)10485760)]
        [InlineData(new byte[] { 0x06, 0x3f, 0xff, 0xd8 }, (uint)104857560)]
        [InlineData(new byte[] { 0xff, 0xff, 0xff, 0xff }, uint.MaxValue)]
        public void BigEndian_Set_UInt32(byte[] expected, uint n)
        {
            var b = new byte[4];

            Binary.BigEndian.Set(n, b, 0);

            Assert.Equal(b, expected);
        }

        [Theory]
        [InlineData(new byte[] { 0x00, 0x00, 0x04, 0x00 }, (uint)1024)]
        [InlineData(new byte[] { 0x00, 0x00, 0x08, 0x00 }, (uint)2048)]
        [InlineData(new byte[] { 0x00, 0x00, 0x10, 0x00 }, (uint)4096)]
        [InlineData(new byte[] { 0x00, 0x00, 0x20, 0x00 }, (uint)8192)]
        [InlineData(new byte[] { 0x00, 0x10, 0x00, 0x00 }, (uint)1048576)]
        [InlineData(new byte[] { 0x00, 0xa0, 0x00, 0x00 }, (uint)10485760)]
        [InlineData(new byte[] { 0x06, 0x3f, 0xff, 0xd8 }, (uint)104857560)]
        [InlineData(new byte[] { 0xff, 0xff, 0xff, 0xff }, uint.MaxValue)]
        public void BigEndian_Set_UInt32_Span(byte[] expected, uint n)
        {
            var b = new byte[4];

            Binary.BigEndian.Set(n, b.AsSpan());

            Assert.Equal(b, expected);
        }

        [Theory]
        [InlineData(new byte[] { 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }, long.MinValue)]
        [InlineData(new byte[] { 0x7f, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff }, long.MaxValue)]
        public void BigEndian_Set_Int64(byte[] expected, long n)
        {
            var b = new byte[8];

            Binary.BigEndian.Set(n, b, 0);

            Assert.Equal(b, expected);
        }

        [Theory]
        [InlineData(new byte[] { 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }, long.MinValue)]
        [InlineData(new byte[] { 0x7f, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff }, long.MaxValue)]
        public void BigEndian_Set_Int64_Span(byte[] expected, long n)
        {
            var b = new byte[8];

            Binary.BigEndian.Set(n, b.AsSpan());

            Assert.Equal(b, expected);
        }

        [Theory]
        [InlineData(new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }, ulong.MinValue)]
        [InlineData(new byte[] { 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff }, ulong.MaxValue)]
        public void BigEndian_Set_UInt64(byte[] expected, ulong n)
        {
            var b = new byte[8];

            Binary.BigEndian.Set(n, b, 0);

            Assert.Equal(b, expected);
        }

        [Theory]
        [InlineData(new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }, ulong.MinValue)]
        [InlineData(new byte[] { 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff }, ulong.MaxValue)]
        public void BigEndian_Set_UInt64_Span(byte[] expected, ulong n)
        {
            var b = new byte[8];

            Binary.BigEndian.Set(n, b.AsSpan());

            Assert.Equal(b, expected);
        }
    }
}

