namespace inverter.Tests
{
    public interface ISerialPort
    {
        void Write(byte[] buffer, int offset, int count);
        int Read(byte[] buffer, int offset, int count);
    }
}