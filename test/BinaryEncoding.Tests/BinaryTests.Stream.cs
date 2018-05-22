using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace BinaryEncoding.Tests
{
    public partial class BinaryTests
    {
        [Fact]
        public void Stream_ReadUInt32()
        {
            var bytes = Binary.BigEndian.GetBytes(uint.MaxValue);
            using (var ms = new MemoryStream(bytes))
            {
                var n = Binary.BigEndian.ReadUInt32(ms);

                Assert.Equal(uint.MaxValue, n);
                Assert.Equal(4, ms.Position);
                Assert.Equal(4, ms.Length);
            }
        }

        [Fact]
        public async Task Async_Stream_ReadUInt32()
        {
            var bytes = Binary.BigEndian.GetBytes(uint.MaxValue);
            using (var ms = new MemoryStream(bytes))
            {
                var n = await Binary.BigEndian.ReadUInt32Async(ms);

                Assert.Equal(uint.MaxValue, n);
                Assert.Equal(4, ms.Position);
                Assert.Equal(4, ms.Length);
            }
        }

        [Fact]
        public void Stream_ReadAndWriteUInt32_BigEndian()
        {
            using (var ms = new MemoryStream())
            {
                Binary.BigEndian.Write(ms, uint.MaxValue);
                ms.Seek(0, SeekOrigin.Begin);
                var n = Binary.BigEndian.ReadUInt32(ms);

                Assert.Equal(uint.MaxValue, n);
                Assert.Equal(4, ms.Position);
                Assert.Equal(4, ms.Length);
            }
        }

        [Fact]
        public async Task Async_Stream_ReadAndWriteUInt32_BigEndian()
        {
            using (var ms = new MemoryStream())
            {
                await Binary.BigEndian.WriteAsync(ms, uint.MaxValue);
                ms.Seek(0, SeekOrigin.Begin);
                var n = await Binary.BigEndian.ReadUInt32Async(ms);

                Assert.Equal(uint.MaxValue, n);
                Assert.Equal(4, ms.Position);
                Assert.Equal(4, ms.Length);
            }
        }

        [Fact]
        public void Stream_ReadAndWriteUInt32_LittleEndian()
        {
            using (var ms = new MemoryStream())
            {
                Binary.LittleEndian.Write(ms, uint.MaxValue);
                ms.Seek(0, SeekOrigin.Begin);
                var n = Binary.LittleEndian.ReadUInt32(ms);

                Assert.Equal(uint.MaxValue, n);
                Assert.Equal(4, ms.Position);
                Assert.Equal(4, ms.Length);
            }
        }

        [Fact]
        public async Task Async_Stream_ReadAndWriteUInt32_LittleEndian()
        {
            using (var ms = new MemoryStream())
            {
                await Binary.LittleEndian.WriteAsync(ms, uint.MaxValue);
                ms.Seek(0, SeekOrigin.Begin);
                var n = await Binary.LittleEndian.ReadUInt32Async(ms);

                Assert.Equal(uint.MaxValue, n);
                Assert.Equal(4, ms.Position);
                Assert.Equal(4, ms.Length);
            }
        }

        [Fact]
        public void Stream_ReadUInt32PastEndOfStream_DoesNotBlock()
        {
            using (var ms = new MemoryStream())
            {
                Binary.BigEndian.Write(ms, uint.MaxValue);
                ms.Seek(0, SeekOrigin.Begin);
                var n = Binary.BigEndian.ReadUInt32(ms);

                Assert.Equal(uint.MaxValue, n);
                Assert.Equal(4, ms.Position);
                Assert.Equal(4, ms.Length);

                Assert.Throws<EndOfStreamException>(() => Binary.BigEndian.ReadUInt32(ms));
            }
        }

        [Fact]
        public void Stream_ReadVarintPastEndOfStream_DoesNotBlock()
        {
            using (var ms = new MemoryStream())
            {
                Binary.Varint.Write(ms, uint.MaxValue);
                ms.Seek(0, SeekOrigin.Begin);
                uint n = 0;
                Binary.Varint.Read(ms, out n);

                Assert.Equal(uint.MaxValue, n);

                Assert.Throws<EndOfStreamException>(() => Binary.Varint.Read(ms, out n));
            }
        }

        [Fact]
        public async Task Async_Stream_ReadUVarintPastEndOfStream_DoesNotBlock()
        {
            using (var ms = new MemoryStream())
            {
                await Binary.Varint.WriteAsync(ms, uint.MaxValue / 2);
                ms.Seek(0, SeekOrigin.Begin);
                var n = await Binary.Varint.ReadAsync(ms);

                Assert.Equal(uint.MaxValue / 2, n);

                await Assert.ThrowsAsync<EndOfStreamException>(() => Binary.Varint.ReadAsync(ms));
            }
        }

        [Fact]
        public async Task Async_Stream_ReadVarintPastEndOfStream_DoesNotBlock()
        {
            using (var ms = new MemoryStream())
            {
                await Binary.Varint.WriteAsync(ms, int.MaxValue / 2);
                ms.Seek(0, SeekOrigin.Begin);
                var n = await Binary.Varint.ReadInt64Async(ms);

                Assert.Equal(int.MaxValue / 2, n);

                await Assert.ThrowsAsync<EndOfStreamException>(() => Binary.Varint.ReadAsync(ms));
            }
        }
    }
}
