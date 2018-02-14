using System.Runtime.CompilerServices;

namespace BinaryEncoding
{
    public static partial class Binary
    {
        private class LittleEndianCodec : EndianCodec
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if UNSAFE
            public override unsafe int Set(ushort value, byte[] bytes, int offset = 0)
            {
                fixed (byte* p = &bytes[offset])
                {
                    *p = (byte)value;
                    *(p + 1) = (byte)(value >> 8);
                }

                return 2;
            }
#else
            public override int Set(ushort value, byte[] bytes, int offset = 0)
            {
                bytes[offset] = (byte)value;
                bytes[offset + 1] = (byte)(value >> 8);

                return 2;
            }
#endif

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if UNSAFE
            public override unsafe int Set(short value, byte[] bytes, int offset = 0)
            {
                fixed (byte* p = &bytes[offset])
                {
                    *p = (byte)value;
                    *(p + 1) = (byte)(value >> 8);
                }

                return 2;
            }
#else
            public override int Set(short value, byte[] bytes, int offset = 0)
            {
                bytes[offset] = (byte)value;
                bytes[offset + 1] = (byte)(value >> 8);

                return 2;
            }
#endif

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if UNSAFE
            public override unsafe int Set(uint value, byte[] bytes, int offset = 0)
            {
                fixed (byte* p = &bytes[offset])
                {
                    *(p) = (byte)value;
                    *(p + 1) = (byte)(value >> 8);
                    *(p + 2) = (byte)(value >> 16);
                    *(p + 3) = (byte)(value >> 24);
                }

                return 4;
            }
#else
            public override int Set(uint value, byte[] bytes, int offset = 0)
            {
                bytes[offset] = (byte)value;
                bytes[offset + 1] = (byte)(value >> 8);
                bytes[offset + 2] = (byte)(value >> 16);
                bytes[offset + 3] = (byte)(value >> 24);

                return 4;
            }
#endif

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if UNSAFE
            public override unsafe int Set(int value, byte[] bytes, int offset = 0)
            {
                fixed (byte* p = &bytes[offset])
                {
                    *(p) = (byte)value;
                    *(p + 1) = (byte)(value >> 8);
                    *(p + 2) = (byte)(value >> 16);
                    *(p + 3) = (byte)(value >> 24);
                }

                return 4;
            }
#else
            public override int Set(int value, byte[] bytes, int offset = 0)
            {
                bytes[offset] = (byte)value;
                bytes[offset + 1] = (byte)(value >> 8);
                bytes[offset + 2] = (byte)(value >> 16);
                bytes[offset + 3] = (byte)(value >> 24);

                return 4;
            }
#endif

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if UNSAFE
            public override unsafe int Set(ulong value, byte[] bytes, int offset = 0)
            {
                fixed (byte* p = &bytes[offset])
                {
                    *p = (byte)value;
                    *(p + 1) = (byte)(value >> 8);
                    *(p + 2) = (byte)(value >> 16);
                    *(p + 3) = (byte)(value >> 24);
                    *(p + 4) = (byte)(value >> 32);
                    *(p + 5) = (byte)(value >> 40);
                    *(p + 6) = (byte)(value >> 48);
                    *(p + 7) = (byte)(value >> 56);
                }

                return 8;
            }
#else
            public override int Set(ulong value, byte[] bytes, int offset = 0)
            {
                bytes[offset] = (byte)value;
                bytes[offset + 1] = (byte)(value >> 8);
                bytes[offset + 2] = (byte)(value >> 16);
                bytes[offset + 3] = (byte)(value >> 24);
                bytes[offset + 4] = (byte)(value >> 32);
                bytes[offset + 5] = (byte)(value >> 40);
                bytes[offset + 6] = (byte)(value >> 48);
                bytes[offset + 7] = (byte)(value >> 56);

                return 8;
            }
#endif

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if UNSAFE
            public override unsafe int Set(long value, byte[] bytes, int offset = 0)
            {
                fixed (byte* p = &bytes[offset])
                {
                    *p = (byte)value;
                    *(p + 1) = (byte)(value >> 8);
                    *(p + 2) = (byte)(value >> 16);
                    *(p + 3) = (byte)(value >> 24);
                    *(p + 4) = (byte)(value >> 32);
                    *(p + 5) = (byte)(value >> 40);
                    *(p + 6) = (byte)(value >> 48);
                    *(p + 7) = (byte)(value >> 56);
                }

                return 8;
            }
#else
            public override int Set(long value, byte[] bytes, int offset = 0)
            {
                bytes[offset] = (byte)value;
                bytes[offset + 1] = (byte)(value >> 8);
                bytes[offset + 2] = (byte)(value >> 16);
                bytes[offset + 3] = (byte)(value >> 24);
                bytes[offset + 4] = (byte)(value >> 32);
                bytes[offset + 5] = (byte)(value >> 40);
                bytes[offset + 6] = (byte)(value >> 48);
                bytes[offset + 7] = (byte)(value >> 56);

                return 8;
            }
#endif

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if UNSAFE
            public override unsafe short GetInt16(byte[] bytes, int offset = 0)
            {
                fixed (byte* p = &bytes[offset])
                {
                    return (short)(*p | *(p + 1) << 8);
                }
            }
#else
            public override short GetInt16(byte[] bytes, int offset = 0)
            {
                return (short)(bytes[offset] | bytes[offset + 1] << 8);
            }
#endif

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if UNSAFE
            public override unsafe ushort GetUInt16(byte[] bytes, int offset = 0)
            {
                fixed (byte* p = &bytes[offset])
                {
                    return (ushort)(*p | *(p + 1) << 8);
                }
            }
#else
            public override ushort GetUInt16(byte[] bytes, int offset = 0)
            {
                return (ushort)(bytes[offset] | (ushort)(bytes[offset + 1] << 8));
            }
#endif

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if UNSAFE
            public override unsafe int GetInt32(byte[] bytes, int offset = 0)
            {
                fixed (byte* p = &bytes[offset])
                {
                    return *p | *(p + 1) << 8 | *(p + 2) << 16 | *(p + 3) << 24;
                }
            }
#else
            public override int GetInt32(byte[] bytes, int offset = 0)
            {
                return bytes[offset] | bytes[offset + 1] << 8 | bytes[offset + 2] << 16 | bytes[offset + 3] << 24;
            }
#endif

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if UNSAFE
            public override unsafe uint GetUInt32(byte[] bytes, int offset = 0)
            {
                fixed (byte* p = &bytes[offset])
                {
                    return (uint)*p | (uint)*(p + 1) << 8 | (uint)*(p + 2) << 16 | (uint)*(p + 3) << 24;
                }
            }
#else
            public override uint GetUInt32(byte[] bytes, int offset = 0)
            {
                return (uint)bytes[offset] | (uint)bytes[offset + 1] << 8 | (uint)bytes[offset + 2] << 16 | (uint)bytes[offset + 3] << 24;
            }
#endif

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if UNSAFE
            public override unsafe long GetInt64(byte[] bytes, int offset = 0)
            {
                fixed (byte* p = &bytes[offset])
                {
                    return (long)*p | (long)*(p + 1) << 8 | (long)*(p + 2) << 16 | (long)*(p + 3) << 24 | (long)*(p + 4) << 32 | (long)*(p + 5) << 40 | (long)*(p + 6) << 48 | (long)*(p + 7) << 56;
                }
            }
#else
            public override long GetInt64(byte[] bytes, int offset = 0)
            {
                return bytes[offset] | (long)bytes[offset + 1] << 8 | (long)bytes[offset + 2] << 16 | (long)bytes[offset + 3] << 24 |
                       (long)bytes[offset + 4] << 32 | (long)bytes[offset + 5] << 40 | (long)bytes[offset + 6] << 48 | (long)bytes[offset + 7] << 56;
            }
#endif

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if UNSAFE
            public override unsafe ulong GetUInt64(byte[] bytes, int offset = 0)
            {
                fixed (byte* p = &bytes[offset])
                {
                    return (ulong)*p | (ulong)*(p + 1) << 8 | (ulong)*(p + 2) << 16 | (ulong)*(p + 3) << 24 | (ulong)*(p + 4) << 32 | (ulong)*(p + 5) << 40 | (ulong)*(p + 6) << 48 | (ulong)*(p + 7) << 56;

                }
            }
#else
            public override ulong GetUInt64(byte[] bytes, int offset = 0)
            {
                return bytes[offset] | (ulong)bytes[offset + 1] << 8 | (ulong)bytes[offset + 2] << 16 | (ulong)bytes[offset + 3] << 24 |
                       (ulong)bytes[offset + 4] << 32 | (ulong)bytes[offset + 5] << 40 | (ulong)bytes[offset + 6] << 48 | (ulong)bytes[offset + 7] << 56;
            }
#endif
        }
    }
}

