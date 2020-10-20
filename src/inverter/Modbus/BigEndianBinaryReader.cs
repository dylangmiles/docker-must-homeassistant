using System;
using System.IO;

namespace inverter.Modbus
{
    public class BigEndianBinaryReader : IDisposable
    {
        private Stream _stream;
        private bool _disposed = false;
        private byte[] _buffer = new byte[16];

        public BigEndianBinaryReader(Stream stream)
        {
            _stream = stream;
        }


        public virtual short ReadInt16()
        {
            _stream.Read(_buffer, 0, 2);
            return (short)(_buffer[1] | _buffer[0] << 8);
        }

        public virtual ushort ReadUInt6()
        {
            var read = _stream.Read(_buffer, 0, 2);
            if (read < 2) throw new EndOfStreamException();

            return (ushort)(_buffer[1] | (uint)_buffer[0] << 8);
        }

        public virtual byte ReadByte()
        {
            var read = _stream.Read(_buffer, 0, 1);
            if (read < 1) throw new EndOfStreamException();

            return (byte)_buffer[0];
        }

        public virtual void Close()
        {
            Dispose(true);
        }


        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (!disposing) return;

            _stream.Close();

            _disposed = true;
        }

        public void Dispose()
        {
            // Dispose of unmanaged resources.
            Dispose(true);
            // Suppress finalization.
            GC.SuppressFinalize(this);
        }

    }
}