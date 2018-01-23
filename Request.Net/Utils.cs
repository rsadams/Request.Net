using System;
using System.Globalization;

namespace Request.Net
{
    /*
     * Utility classes to convert between various data types 
    */
    public static class Utils
    {
        /*
         * Converts a hex string in the format "0xa0f9348269095faeb497d8de0b892d542de6d48e3583363b8c77542561f4e375"
         * to a 32byte array.
        */
        public static byte[] HexStringToByte32(string input)
        {
            if (!input.StartsWith("0x"))
            {
                throw new ArgumentException("Hex strings must start with 0x");
            }

            if (input.Length != 66)
            {
                throw new ArgumentException("Hex strings should be 66 characters long");
            }

            // Strip the 0x pre-fix
            input = input.Remove(0, 2);

            // Convert to Hex
            var bytes = new byte[input.Length / 2];
            for (int index = 0; index < bytes.Length; index++)
            {
                string byteValue = input.Substring(index * 2, 2);
                bytes[index] = byte.Parse(byteValue, NumberStyles.HexNumber);
            }

            return bytes; 
        }
    }
}
