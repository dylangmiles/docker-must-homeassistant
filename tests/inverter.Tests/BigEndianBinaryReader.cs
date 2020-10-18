using System;
using System.IO;

namespace inverter.Tests
{
    internal class BigEndianBinaryReader : IDisposable
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
            return (short) ((int) _buffer[1] | (int) _buffer[0] << 8);
        }

        public virtual ushort ReadUInt6()
        {
            var read = _stream.Read(_buffer, 0, 2);
            if (read < 2) throw new EndOfStreamException();

            return (ushort) ((uint) _buffer[1] | (uint) _buffer[0] << 8);
        }

        public virtual byte ReadByte()
        {
            var value = _stream.ReadByte();
            if (value == -1 ) throw new EndOfStreamException();

            return (byte)value;
        }

        public virtual void Close()
        {
            this.Dispose(true);
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