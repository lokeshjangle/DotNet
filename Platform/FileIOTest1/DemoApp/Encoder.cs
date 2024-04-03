static class Encoder
{
    public static void Encode(byte[] data, int count)
    {
        for(int i = 0; i < count; ++i)
        {
            data[i] = (byte)(data[i] ^ '#');
        }
    }
}
