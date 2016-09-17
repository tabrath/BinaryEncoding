using System.IO;
using NUnit.Framework;

namespace BinaryEncoding.Tests
{
    public partial class BinaryTests
    {
        [Test]
        public void Stream_ReadUInt32()
        {
            var bytes = Binary.BigEndian.GetBytes(uint.MaxValue);
            using (var ms = new MemoryStream(bytes))
            {
                var n = Binary.BigEndian.ReadUInt32(ms);

                Assert.That(n, Is.EqualTo(uint.MaxValue));
                Assert.That(ms.Position, Is.EqualTo(4));
                Assert.That(ms.Length, Is.EqualTo(4));
            }
        }

        [Test]
        public void Stream_ReadAndWriteUInt32()
        {
            using (var ms = new MemoryStream())
            {
                Binary.BigEndian.Write(ms, uint.MaxValue);
                ms.Seek(0, SeekOrigin.Begin);
                var n = Binary.BigEndian.ReadUInt32(ms);

                Assert.That(n, Is.EqualTo(uint.MaxValue));
                Assert.That(ms.Position, Is.EqualTo(4));
                Assert.That(ms.Length, Is.EqualTo(4));
            }
        }
    }
}
