using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace BinaryEncoding
{
    public partial class Binary
    {
        public abstract partial class EndianCodec
        {
            public static IBufferPool BufferPool = null;

            private static byte[] GetBuffer(int size) => BufferPool != null ? BufferPool.Rent(size) : new byte[size];
            private static void FreeBuffer(byte[] buffer) => BufferPool?.Return(buffer);

            private static T Read<T>(Stream stream, Func<byte[], int, T> func)
            {
                if (stream == null)
                    throw new ArgumentNullException(nameof(stream));

                if (!stream.CanRead)
                    throw new Exception("Stream is not readable");

                var size = Marshal.SizeOf(typeof(T));
                var buffer = GetBuffer(size);
                var bytesRead = stream.Read(buffer, 0, size);
                if (bytesRead <= 0)
                    throw new EndOfStreamException();

                if (bytesRead != size)
                    throw new Exception("Could not read full length");

                T result = func(buffer, 0);
                FreeBuffer(buffer);
                return result;
            }

            private static async Task<T> ReadAsync<T>(Stream stream, Func<byte[], int, T> func)
            {
                if (stream == null)
                    throw new ArgumentNullException(nameof(stream));

                if (!stream.CanRead)
                    throw new Exception("Stream is not readable");

                var size = Marshal.SizeOf(typeof(T));
                var buffer = GetBuffer(size);
                var bytesRead = await stream.ReadAsync(buffer, 0, size);
                if (bytesRead <= 0)
                    throw new EndOfStreamException();
                if (bytesRead != buffer.Length)
                    throw new Exception("Could not read full length");

                T result = func(buffer, 0);
                FreeBuffer(buffer);
                return result;
            }

            public short ReadInt16(Stream stream) => Read(stream, GetInt16);
            public int ReadInt32(Stream stream) => Read(stream, GetInt32);
            public long ReadInt64(Stream stream) => Read(stream, GetInt64);
            public ushort ReadUInt16(Stream stream) => Read(stream, GetUInt16);
            public uint ReadUInt32(Stream stream) => Read(stream, GetUInt32);
            public ulong ReadUInt64(Stream stream) => Read(stream, GetUInt64);

            public Task<short> ReadInt16Async(Stream stream) => ReadAsync(stream, GetInt16);
            public Task<int> ReadInt32Async(Stream stream) => ReadAsync(stream, GetInt32);
            public Task<long> ReadInt64Async(Stream stream) => ReadAsync(stream, GetInt64);
            public Task<ushort> ReadUInt16Async(Stream stream) => ReadAsync(stream, GetUInt16);
            public Task<uint> ReadUInt32Async(Stream stream) => ReadAsync(stream, GetUInt32);
            public Task<ulong> ReadUInt64Async(Stream stream) => ReadAsync(stream, GetUInt64);

            public IEnumerable<short> ReadInt16(Stream stream, int count) => Enumerable.Range(0, count).Select(_ => ReadInt16(stream));
            public IEnumerable<int> ReadInt32(Stream stream, int count) => Enumerable.Range(0, count).Select(_ => ReadInt32(stream));
            public IEnumerable<long> ReadInt64(Stream stream, int count) => Enumerable.Range(0, count).Select(_ => ReadInt64(stream));
            public IEnumerable<ushort> ReadUInt16(Stream stream, int count) => Enumerable.Range(0, count).Select(_ => ReadUInt16(stream));
            public IEnumerable<uint> ReadUInt32(Stream stream, int count) => Enumerable.Range(0, count).Select(_ => ReadUInt32(stream));
            public IEnumerable<ulong> ReadUInt64(Stream stream, int count) => Enumerable.Range(0, count).Select(_ => ReadUInt64(stream));

            public Task<short[]> ReadInt16Async(Stream stream, int count) => Task.WhenAll(Enumerable.Range(0, count).Select(_ => ReadInt16Async(stream)));
            public Task<int[]> ReadInt32Async(Stream stream, int count) => Task.WhenAll(Enumerable.Range(0, count).Select(_ => ReadInt32Async(stream)));
            public Task<long[]> ReadInt64Async(Stream stream, int count) => Task.WhenAll(Enumerable.Range(0, count).Select(_ => ReadInt64Async(stream)));
            public Task<ushort[]> ReadUInt16Async(Stream stream, int count) => Task.WhenAll(Enumerable.Range(0, count).Select(_ => ReadUInt16Async(stream)));
            public Task<uint[]> ReadUInt32Async(Stream stream, int count) => Task.WhenAll(Enumerable.Range(0, count).Select(_ => ReadUInt32Async(stream)));
            public Task<ulong[]> ReadUInt64Async(Stream stream, int count) => Task.WhenAll(Enumerable.Range(0, count).Select(_ => ReadUInt64Async(stream)));

            private static int Write<T>(Stream stream, T value, Func<T, byte[], int, int> func)
            {
                if (stream == null)
                    throw new ArgumentNullException(nameof(stream));

                if (!stream.CanWrite)
                    throw new Exception("Stream is not writable");

                var size = Marshal.SizeOf(typeof(T));
                var buffer = GetBuffer(size);
                var length = func(value, buffer, 0);
                stream.Write(buffer, 0, size);
                FreeBuffer(buffer);
                return length;
            }

            private static async Task<int> WriteAsync<T>(Stream stream, T value, Func<T, byte[], int, int> func)
            {
                if (stream == null)
                    throw new ArgumentNullException(nameof(stream));

                if (!stream.CanWrite)
                    throw new Exception("Stream is not writable");

                var size = Marshal.SizeOf(typeof(T));
                var buffer = GetBuffer(size);
                var length = func(value, buffer, 0);
                await stream.WriteAsync(buffer, 0, size);
                FreeBuffer(buffer);
                return length;
            }

            public int Write(Stream stream, short value) => Write(stream, value, Set);
            public int Write(Stream stream, int value) => Write(stream, value, Set);
            public int Write(Stream stream, long value) => Write(stream, value, Set);
            public int Write(Stream stream, ushort value) => Write(stream, value, Set);
            public int Write(Stream stream, uint value) => Write(stream, value, Set);
            public int Write(Stream stream, ulong value) => Write(stream, value, Set);

            public Task<int> WriteAsync(Stream stream, short value) => WriteAsync(stream, value, Set);
            public Task<int> WriteAsync(Stream stream, int value) => WriteAsync(stream, value, Set);
            public Task<int> WriteAsync(Stream stream, long value) => WriteAsync(stream, value, Set);
            public Task<int> WriteAsync(Stream stream, ushort value) => WriteAsync(stream, value, Set);
            public Task<int> WriteAsync(Stream stream, uint value) => WriteAsync(stream, value, Set);
            public Task<int> WriteAsync(Stream stream, ulong value) => WriteAsync(stream, value, Set);

            public int Write(Stream stream, params short[] values) => values.Select(v => Write(stream, v)).Sum();
            public int Write(Stream stream, params int[] values) => values.Select(v => Write(stream, v)).Sum();
            public int Write(Stream stream, params long[] values) => values.Select(v => Write(stream, v)).Sum();
            public int Write(Stream stream, params ushort[] values) => values.Select(v => Write(stream, v)).Sum();
            public int Write(Stream stream, params uint[] values) => values.Select(v => Write(stream, v)).Sum();
            public int Write(Stream stream, params ulong[] values) => values.Select(v => Write(stream, v)).Sum();

            public Task<int> WriteAsync(Stream stream, params short[] values) => Task.WhenAll(values.Select(v => WriteAsync(stream, v))).ContinueWith(t => t.Result.Sum());
            public Task<int> WriteAsync(Stream stream, params int[] values) => Task.WhenAll(values.Select(v => WriteAsync(stream, v))).ContinueWith(t => t.Result.Sum());
            public Task<int> WriteAsync(Stream stream, params long[] values) => Task.WhenAll(values.Select(v => WriteAsync(stream, v))).ContinueWith(t => t.Result.Sum());
            public Task<int> WriteAsync(Stream stream, params ushort[] values) => Task.WhenAll(values.Select(v => WriteAsync(stream, v))).ContinueWith(t => t.Result.Sum());
            public Task<int> WriteAsync(Stream stream, params uint[] values) => Task.WhenAll(values.Select(v => WriteAsync(stream, v))).ContinueWith(t => t.Result.Sum());
            public Task<int> WriteAsync(Stream stream, params ulong[] values) => Task.WhenAll(values.Select(v => WriteAsync(stream, v))).ContinueWith(t => t.Result.Sum());
        }
    }
}

