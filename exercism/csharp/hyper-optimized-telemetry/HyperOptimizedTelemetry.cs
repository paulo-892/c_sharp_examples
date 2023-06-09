using System;
using System.Linq;

public static class TelemetryBuffer
{
    public static byte[] ToBuffer(long reading)
    {
        byte[] bytes = BitConverter.GetBytes(reading);
        Console.WriteLine(string.Join(",", bytes));
        byte prefixByte;
        int length;
        
        if (reading is <= -2_147_483_649 or >= 4_294_967_296)
        {
            prefixByte = (byte)(256 - 8);
            length = 8;
        }
        else if (reading >= 2_147_483_648)
        {
            prefixByte = (byte)(4);
            length = 4;
        }
        else if (reading is <= -32_769 or >= 65_536)
        {
            
            prefixByte = (byte)(256 - 4);
            length = 4;
        }
        else if (reading <= -1)
        {
            prefixByte = (byte)(256 - 2);
            length = 2;
        }
        else
        {
            prefixByte = (byte)2;
            length = 2;
        }

        byte[] resultBytes = new byte[bytes.Length + 1];
        resultBytes[0] = prefixByte;
        Array.Copy(bytes, 0, resultBytes, 1, length);
        
        return resultBytes;
    }

    public static long FromBuffer(byte[] buffer)
    {
        int prefixByte = buffer[0];
        var validPrefixes = new[] { 248, 252, 254, 2, 4 };

        if (!validPrefixes.Contains(prefixByte)) return 0;
        
        if (prefixByte == 4)
        {
            return BitConverter.ToUInt32(buffer, 1);
        }
        else if (prefixByte == 2)
        {
            return BitConverter.ToUInt16(buffer, 1);
        }
        else if (prefixByte == 254)
        {
            return BitConverter.ToInt16(buffer, 1);
        }
        else if (prefixByte == 252)
        {
            return BitConverter.ToInt32(buffer, 1);
        }
        else
        {
            return BitConverter.ToInt64(buffer, 1);
        }
    }
}
