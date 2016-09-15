using System.Runtime.CompilerServices;

namespace BinaryEncoding
{
    public static partial class Binary
    {
        private class BigEndianCodec : EndianCodec
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if UNSAFE
            public override unsafe int Set(ushort value, byte[] bytes, int offset = 0)
            {
                fixed (byte* p = &bytes[offset])
                {
                    *p = (byte)(value >> 8);
                    *(p + 1) = (byte)value;
                }

                return 2;
            }
#else
            public override int Set(ushort value, byte[] bytes, int offset = 0)
            {
                bytes[offset] = (byte)(value >> 8);
                bytes[offset + 1] = (byte)value;

                return 2;
            }
#endif

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if UNSAFE
            public override unsafe int Set(short value, byte[] bytes, int offset = 0)
            {
                fixed (byte* p = &bytes[offset])
                {
                    *p = (byte)(value >> 8);
                    *(p + 1) = (byte)value;
                }

                return 2;
            }
#else
            public override int Set(short value, byte[] bytes, int offset = 0)
            {
                bytes[offset] = (byte)(value >> 8);
                bytes[offset + 1] = (byte)value;

                return 2;
            }
#endif

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if UNSAFE
            public override unsafe int Set(uint value, byte[] bytes, int offset = 0)
            {
                fixed (byte* p = &bytes[offset])
                {
                    *p = (byte)(value >> 24);
                    *(p + 1) = (byte)(value >> 16);
                    *(p + 2) = (byte)(value >> 8);
                    *(p + 3) = (byte)value;
                }

                return 4;
            }
#else
            public override int Set(uint value, byte[] bytes, int offset = 0)
            {
                bytes[offset] = (byte)(value >> 24);
                bytes[offset + 1] = (byte)(value >> 16);
                bytes[offset + 2] = (byte)(value >> 8);
                bytes[offset + 3] = (byte)value;

                return 4;
            }
#endif

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if UNSAFE
            public override unsafe int Set(int value, byte[] bytes, int offset = 0)
            {
                fixed (byte* p = &bytes[offset])
                {
                    *p = (byte)(value >> 24);
                    *(p + 1) = (byte)(value >> 16);
                    *(p + 2) = (byte)(value >> 8);
                    *(p + 3) = (byte)value;
                }

                return 4;
            }
#else
            public override int Set(int value, byte[] bytes, int offset = 0)
            {
                bytes[offset] = (byte)(value >> 24);
                bytes[offset + 1] = (byte)(value >> 16);
                bytes[offset + 2] = (byte)(value >> 8);
                bytes[offset + 3] = (byte)value;

                return 4;
            }
#endif

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if UNSAFE
            public override unsafe int Set(ulong value, byte[] bytes, int offset = 0)
            {
                fixed (byte* p = &bytes[offset])
                {
                    *p = (byte)(value >> 56);
                    *(p + 1) = (byte)(value >> 48);
                    *(p + 2) = (byte)(value >> 40);
                    *(p + 3) = (byte)(value >> 32);
                    *(p + 4) = (byte)(value >> 24);
                    *(p + 5) = (byte)(value >> 16);
                    *(p + 6) = (byte)(value >> 8);
                    *(p + 7) = (byte)value;
                }

                return 8;
            }
#else
            public override int Set(ulong value, byte[] bytes, int offset = 0)
            {
                bytes[offset] = (byte)(value >> 56);
                bytes[offset + 1] = (byte)(value >> 48);
                bytes[offset + 2] = (byte)(value >> 40);
                bytes[offset + 3] = (byte)(value >> 32);
                bytes[offset + 4] = (byte)(value >> 24);
                bytes[offset + 5] = (byte)(value >> 16);
                bytes[offset + 6] = (byte)(value >> 8);
                bytes[offset + 7] = (byte)value;

                return 8;
            }
#endif

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if UNSAFE
            public override unsafe int Set(long value, byte[] bytes, int offset = 0)
            {
                fixed (byte* p = &bytes[offset])
                {
                    *p = (byte)(value >> 56);
                    *(p + 1) = (byte)(value >> 48);
                    *(p + 2) = (byte)(value >> 40);
                    *(p + 3) = (byte)(value >> 32);
                    *(p + 4) = (byte)(value >> 24);
                    *(p + 5) = (byte)(value >> 16);
                    *(p + 6) = (byte)(value >> 8);
                    *(p + 7) = (byte)value;
                }

                return 8;
            }
#else
            public override int Set(long value, byte[] bytes, int offset = 0)
            {
                bytes[offset] = (byte)(value >> 56);
                bytes[offset + 1] = (byte)(value >> 48);
                bytes[offset + 2] = (byte)(value >> 40);
                bytes[offset + 3] = (byte)(value >> 32);
                bytes[offset + 4] = (byte)(value >> 24);
                bytes[offset + 5] = (byte)(value >> 16);
                bytes[offset + 6] = (byte)(value >> 8);
                bytes[offset + 7] = (byte)value;

                return 8;
            }
#endif

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if UNSAFE
            public override unsafe short GetInt16(byte[] bytes, int offset = 0)
            {
                fixed (byte* p = &bytes[offset])
                {
                    return (short)(*(p + 1) | *p << 8);
                }
            }
#else
            public override short GetInt16(byte[] bytes, int offset = 0)
            {
                return (short)(bytes[offset + 1] | bytes[offset] << 8);
            }
#endif

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if UNSAFE
            public override unsafe ushort GetUInt16(byte[] bytes, int offset = 0)
            {
                fixed (byte* p = &bytes[offset])
                {
                    return (ushort)(*(p + 1) | *p << 8);
                }
            }
#else
            public override ushort GetUInt16(byte[] bytes, int offset = 0)
            {
                return (ushort)(bytes[offset + 1] | bytes[offset] << 8);
            }
#endif

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if UNSAFE
            public override unsafe int GetInt32(byte[] bytes, int offset = 0)
            {
                fixed (byte* p = &bytes[offset])
                {
                    return *(p + 3) | *(p + 2) << 8 | *(p + 1) << 16 | *p << 24;
                }
            }
#else
            public override int GetInt32(byte[] bytes, int offset = 0)
            {
                return bytes[offset + 3] | bytes[offset + 2] << 8 | bytes[offset + 1] << 16 | bytes[offset] << 24;
            }
#endif

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if UNSAFE
            public override unsafe uint GetUInt32(byte[] bytes, int offset = 0)
            {
                fixed (byte* p = &bytes[offset])
                {
                    return *(p + 3) | (uint)*(p + 2) << 8 | (uint)*(p + 1) << 16 | (uint)*p << 24;
                }
            }
#else
            public override uint GetUInt32(byte[] bytes, int offset = 0)
            {
                return bytes[offset + 3] | (uint)bytes[offset + 2] << 8 | (uint)bytes[offset + 1] << 16 | (uint)bytes[offset] << 24;
            }
#endif

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if UNSAFE
            public override unsafe long GetInt64(byte[] bytes, int offset = 0)
            {
                fixed (byte* p = &bytes[offset])
                {
                    return *(p + 7) | (long)*(p + 6) << 8 | (long)*(p + 5) << 16 | (long)*(p + 4) << 24 |
                           (long)*(p + 3) << 32 | (long)*(p + 2) << 40 | (long)*(p + 1) << 48 | (long)*p << 56;
                }
            }
#else
            public override long GetInt64(byte[] bytes, int offset = 0)
            {
                return bytes[offset + 7] | (long)bytes[offset + 6] << 8 | (long)bytes[offset + 5] << 16 | (long)bytes[offset + 4] << 24 |
                       (long)bytes[offset + 3] << 32 | (long)bytes[offset + 2] << 40 | (long)bytes[offset + 1] << 48 | (long)bytes[offset] << 56;
            }
#endif

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if UNSAFE
            public override unsafe ulong GetUInt64(byte[] bytes, int offset = 0)
            {
                fixed (byte* p = &bytes[offset])
                {
                    return *(p + 7) | (ulong)*(p + 6) << 8 | (ulong)*(p + 5) << 16 | (ulong)*(p + 4) << 24 |
                           (ulong)*(p + 3) << 32 | (ulong)*(p + 2) << 40 | (ulong)*(p + 1) << 48 | (ulong)*p << 56;
                }
            }
#else
            public override ulong GetUInt64(byte[] bytes, int offset = 0)
            {
                return bytes[offset + 7] | (ulong)bytes[offset + 6] << 8 | (ulong)bytes[offset + 5] << 16 | (ulong)bytes[offset + 4] << 24 |
                       (ulong)bytes[offset + 3] << 32 | (ulong)bytes[offset + 2] << 40 | (ulong)bytes[offset + 1] << 48 | (ulong)bytes[offset] << 56;
            }
#endif
        }
    }
}

