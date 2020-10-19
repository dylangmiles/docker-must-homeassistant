using System;

namespace inverter.Tests.Modbus
{
    public class Utils
    {
        /// <summary>
        /// Calculates the Modbus CRC given a message.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static ushort CalculateCrc(byte[] message, int offset, int count)
        {
            ushort crcFull = 0xFFFF;
            byte crcHigh = 0xFF, crcLow = 0xFF;
            char crcLsb;
 
            for (int i = 0; i < count; i++)
            {
                crcFull = (ushort)(crcFull ^ message[offset + i]);
 
                for (int j = 0; j < 8; j++)
                {
                    crcLsb = (char)(crcFull & 0x0001);
                    crcFull = (ushort)((crcFull >> 1) & 0x7FFF);
 
                    if (crcLsb == 1)
                        crcFull = (ushort)(crcFull ^ 0xA001);
                }
            }
            crcHigh = (byte)((crcFull >> 8) & 0xFF);
            crcLow = (byte)(crcFull & 0xFF);

            return (ushort) ((uint) crcLow | (uint) crcHigh << 8);
        }
    }
}