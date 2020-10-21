using System;
using System.Buffers.Binary;
using System.IO;
using System.Net;

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


        public virtual ushort ReadUInt6()
        {

            var read = _stream.Read(_buffer, 0, 2);
            if (read < 2) throw new EndOfStreamException();

            ReadOnlySpan<byte> span = _buffer;
            return BinaryPrimitives.ReadUInt16BigEndian(span.Slice(0, 2));
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