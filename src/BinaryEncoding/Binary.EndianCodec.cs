using System;

namespace BinaryEncoding
{
    public static partial class Binary
    {
        public abstract partial class EndianCodec
        {
            public abstract short GetInt16(byte[] bytes, int offset = 0);
            public abstract ushort GetUInt16(byte[] bytes, int offset = 0);
            public abstract int GetInt32(byte[] bytes, int offset = 0);
            public abstract uint GetUInt32(byte[] bytes, int offset = 0);
            public abstract long GetInt64(byte[] bytes, int offset = 0);
            public abstract ulong GetUInt64(byte[] bytes, int offset = 0);

            public abstract short GetInt16(ReadOnlySpan<byte> bytes);
            public abstract ushort GetUInt16(ReadOnlySpan<byte> bytes);
            public abstract int GetInt32(ReadOnlySpan<byte> bytes);
            public abstract uint GetUInt32(ReadOnlySpan<byte> bytes);
            public abstract long GetInt64(ReadOnlySpan<byte> bytes);
            public abstract ulong GetUInt64(ReadOnlySpan<byte> bytes);

            public abstract int Set(short value, byte[] bytes, int offset = 0);
            public abstract int Set(ushort value, byte[] bytes, int offset = 0);
            public abstract int Set(int value, byte[] bytes, int offset = 0);
            public abstract int Set(uint value, byte[] bytes, int offset = 0);
            public abstract int Set(long value, byte[] bytes, int offset = 0);
            public abstract int Set(ulong value, byte[] bytes, int offset = 0);

            public abstract int Set(short value, Span<byte> bytes);
            public abstract int Set(ushort value, Span<byte> bytes);
            public abstract int Set(int value, Span<byte> bytes);
            public abstract int Set(uint value, Span<byte> bytes);
            public abstract int Set(long value, Span<byte> bytes);
            public abstract int Set(ulong value, Span<byte> bytes);
        }
    }
}

