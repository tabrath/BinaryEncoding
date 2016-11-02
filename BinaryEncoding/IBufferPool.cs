namespace BinaryEncoding
{
    public interface IBufferPool
    {
        byte[] Rent(int size);
        void Return(byte[] buffer);
    }
}