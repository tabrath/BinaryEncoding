using System;
using System.Runtime.CompilerServices;

namespace BinaryEncoding
{
    public static partial class Binary
    {
        private class LittleEndianCodec : EndianCodec
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public override int Set(ushort value, Span<byte> bytes)
            {
                bytes[0] = (byte)value;
                bytes[1] = (byte)(value >> 8);

                return 2;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public override int Set(ushort value, byte[] bytes, int offset = 0) => Set(value, bytes.AsSpan(offset));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public override int Set(short value, Span<byte> bytes)
            {
                bytes[0] = (byte)value;
                bytes[1] = (byte)(value >> 8);

                return 2;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public override int Set(short value, byte[] bytes, int offset = 0) => Set(value, bytes.AsSpan(offset));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public override int Set(uint value, Span<byte> bytes)
            {
                bytes[0] = (byte)value;
                bytes[1] = (byte)(value >> 8);
                bytes[2] = (byte)(value >> 16);
                bytes[3] = (byte)(value >> 24);

                return 4;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public override int Set(uint value, byte[] bytes, int offset = 0) => Set(value, bytes.AsSpan(offset));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public override int Set(int value, Span<byte> bytes)
            {
                bytes[0] = (byte)value;
                bytes[1] = (byte)(value >> 8);
                bytes[2] = (byte)(value >> 16);
                bytes[3] = (byte)(value >> 24);

                return 4;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public override int Set(int value, byte[] bytes, int offset = 0) => Set(value, bytes.AsSpan(offset));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public override int Set(ulong value, Span<byte> bytes)
            {
                bytes[0] = (byte)value;
                bytes[1] = (byte)(value >> 8);
                bytes[2] = (byte)(value >> 16);
                bytes[3] = (byte)(value >> 24);
                bytes[4] = (byte)(value >> 32);
                bytes[5] = (byte)(value >> 40);
                bytes[6] = (byte)(value >> 48);
                bytes[7] = (byte)(value >> 56);

                return 8;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public override int Set(ulong value, byte[] bytes, int offset = 0) => Set(value, bytes.AsSpan(offset));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public override int Set(long value, Span<byte> bytes)
            {
                bytes[0] = (byte)value;
                bytes[1] = (byte)(value >> 8);
                bytes[2] = (byte)(value >> 16);
                bytes[3] = (byte)(value >> 24);
                bytes[4] = (byte)(value >> 32);
                bytes[5] = (byte)(value >> 40);
                bytes[6] = (byte)(value >> 48);
                bytes[7] = (byte)(value >> 56);

                return 8;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public override int Set(long value, byte[] bytes, int offset = 0) => Set(value, bytes.AsSpan(offset));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public override short GetInt16(ReadOnlySpan<byte> bytes) => (short)(bytes[0] | bytes[1] << 8);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public override short GetInt16(byte[] bytes, int offset = 0) => GetInt16(bytes.AsSpan(offset));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public override ushort GetUInt16(ReadOnlySpan<byte> bytes) => (ushort)(bytes[0] | (ushort)(bytes[1] << 8));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public override ushort GetUInt16(byte[] bytes, int offset = 0) => GetUInt16(bytes.AsSpan(offset));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public override int GetInt32(ReadOnlySpan<byte> bytes) =>
                bytes[0] |
                bytes[1] << 8 |
                bytes[2] << 16 |
                bytes[3] << 24;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public override int GetInt32(byte[] bytes, int offset = 0) => GetInt32(bytes.AsSpan(offset));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public override uint GetUInt32(ReadOnlySpan<byte> bytes) =>
                (uint)bytes[0] |
                (uint)bytes[1] << 8 |
                (uint)bytes[2] << 16 |
                (uint)bytes[3] << 24;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public override uint GetUInt32(byte[] bytes, int offset = 0) => GetUInt32(bytes.AsSpan(offset));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public override long GetInt64(ReadOnlySpan<byte> bytes) =>
                (long)bytes[0] |
                (long)bytes[1] << 8 |
                (long)bytes[2] << 16 |
                (long)bytes[3] << 24 |
                (long)bytes[4] << 32 |
                (long)bytes[5] << 40 |
                (long)bytes[6] << 48 |
                (long)bytes[7] << 56;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public override long GetInt64(byte[] bytes, int offset = 0) => GetInt64(bytes.AsSpan(offset));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public override ulong GetUInt64(ReadOnlySpan<byte> bytes) =>
                (ulong)bytes[0] |
                (ulong)bytes[1] << 8 |
                (ulong)bytes[2] << 16 |
                (ulong)bytes[3] << 24 |
                (ulong)bytes[4] << 32 |
                (ulong)bytes[5] << 40 |
                (ulong)bytes[6] << 48 |
                (ulong)bytes[7] << 56;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public override ulong GetUInt64(byte[] bytes, int offset = 0) => GetUInt64(bytes.AsSpan(offset));
        }
    }
}
