using NUnit.Framework;

namespace BinaryEncoding.Tests
{
    public partial class BinaryTests
    {
        [TestCase(new byte[] { 0x00, 0x80 }, short.MinValue)]
        [TestCase(new byte[] { 0xff, 0x7f }, short.MaxValue)]
        public void LittleEndian_GetInt16(byte[] bytes, int expected)
        {
            var decoded = Binary.LittleEndian.GetInt16(bytes, 0);

            Assert.That(decoded, Is.EqualTo(expected));
        }

        [TestCase(new byte[] { 0x00, 0x00 }, ushort.MinValue)]
        [TestCase(new byte[] { 0xff, 0xff }, ushort.MaxValue)]
        public void LittleEndian_GetUInt16(byte[] bytes, uint expected)
        {
            var decoded = Binary.LittleEndian.GetUInt16(bytes, 0);

            Assert.That(decoded, Is.EqualTo(expected));
        }

        [TestCase(new byte[] { 0x00, 0x00, 0x00, 0x80 }, int.MinValue)]
        [TestCase(new byte[] { 0xff, 0xff, 0xff, 0x7f }, int.MaxValue)]
        public void LittleEndian_GetInt32(byte[] bytes, int expected)
        {
            var decoded = Binary.LittleEndian.GetInt32(bytes, 0);

            Assert.That(decoded, Is.EqualTo(expected));
        }

        [TestCase(new byte[] { 0x00, 0x00, 0x00, 0x00 }, uint.MinValue)]
        [TestCase(new byte[] { 0xff, 0xff, 0xff, 0xff }, uint.MaxValue)]
        public void LittleEndian_GetUInt32(byte[] bytes, uint expected)
        {
            var decoded = Binary.LittleEndian.GetUInt32(bytes, 0);

            Assert.That(decoded, Is.EqualTo(expected));
        }

        [TestCase(new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x80 }, long.MinValue)]
        [TestCase(new byte[] { 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0x7f }, long.MaxValue)]
        public void LittleEndian_GetInt64(byte[] bytes, long expected)
        {
            var decoded = Binary.LittleEndian.GetInt64(bytes, 0);

            Assert.That(decoded, Is.EqualTo(expected));
        }

        [TestCase(new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }, ulong.MinValue)]
        [TestCase(new byte[] { 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff }, ulong.MaxValue)]
        public void LittleEndian_GetUInt64(byte[] bytes, ulong expected)
        {
            var decoded = Binary.LittleEndian.GetUInt64(bytes, 0);

            Assert.That(decoded, Is.EqualTo(expected));
        }

        [TestCase(new byte[] { 0x00, 0x80 }, short.MinValue)]
        [TestCase(new byte[] { 0xff, 0x7f }, short.MaxValue)]
        public void LittleEndian_Set_Int16(byte[] expected, short n)
        {
            var b = new byte[2];

            Binary.LittleEndian.Set(n, b, 0);

            Assert.That(b, Is.EqualTo(expected));
        }

        [TestCase(new byte[] { 0x00, 0x00 }, ushort.MinValue)]
        [TestCase(new byte[] { 0xff, 0xff }, ushort.MaxValue)]
        public void LittleEndian_Set_UInt16(byte[] expected, ushort n)
        {
            var b = new byte[2];

            Binary.LittleEndian.Set(n, b, 0);

            Assert.That(b, Is.EqualTo(expected));
        }

        [TestCase(new byte[] { 0x00, 0x00, 0x00, 0x80 }, int.MinValue)]
        [TestCase(new byte[] { 0xff, 0xff, 0xff, 0x7f }, int.MaxValue)]
        public void LittleEndian_Set_Int32(byte[] expected, int n)
        {
            var b = new byte[4];

            Binary.LittleEndian.Set(n, b, 0);

            Assert.That(b, Is.EqualTo(expected));
        }

        [TestCase(new byte[] { 0x00, 0x00, 0x00, 0x00 }, uint.MinValue)]
        [TestCase(new byte[] { 0xff, 0xff, 0xff, 0xff }, uint.MaxValue)]
        public void LittleEndian_Set_UInt32(byte[] expected, uint n)
        {
            var b = new byte[4];

            Binary.LittleEndian.Set(n, b, 0);

            Assert.That(b, Is.EqualTo(expected));
        }

        [TestCase(new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x80 }, long.MinValue)]
        [TestCase(new byte[] { 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0x7f }, long.MaxValue)]
        public void LittleEndian_Set_Int64(byte[] expected, long n)
        {
            var b = new byte[8];

            Binary.LittleEndian.Set(n, b, 0);

            Assert.That(b, Is.EqualTo(expected));
        }

        [TestCase(new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }, ulong.MinValue)]
        [TestCase(new byte[] { 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff }, ulong.MaxValue)]
        public void LittleEndian_Set_UInt64(byte[] expected, ulong n)
        {
            var b = new byte[8];

            Binary.LittleEndian.Set(n, b, 0);

            Assert.That(b, Is.EqualTo(expected));
        }
    }
}

