﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace ConverterApp.Models
{
    public class Converter
    {
        /// <summary>
        /// A more mathmatical approach to ASCII to Binary conversion
        /// https://forums.asp.net/t/1713174.aspx?How+to+convert+ASCII+value+to+binary+value+using+c+net
        /// </summary>
        /// <param name="data">String to convert</param>
        /// <returns>Binary encoded string</returns>
        public static string StringToBinary2(string data)
        {
            string converted = string.Empty;
            // convert string to byte array
            byte[] bytes = Encoding.ASCII.GetBytes(data);

            for (int i = 0; i < bytes.Length; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    converted += (bytes[i] & 0x80) > 0 ? "1" : "0";
                    bytes[i] <<= 1;
                }
            }

            return converted;
        }


        /// <summary>
        /// Convert a Binary text string to a Text string
        /// </summary>
        /// <param name="text">Binary encoded string</param>
        /// <returns>Text string</returns>
        public static string BinaryToString(string text)
        {
            List<byte> bytes = new List<byte>();

            for (int i = 0; i < text.Length; i += 8)
            {
                bytes.Add(Convert.ToByte(text.Substring(i, 8), 2));
            }
            return Encoding.ASCII.GetString(bytes.ToArray());
        }


        /// <summary>
        /// An approach to ASCII to Hexadecimal conversion using ToString("X2")
        /// </summary>
        /// <param name="data">String to convert</param>
        /// <returns></returns>
        public static string StringToHex2(string data)
        {
            StringBuilder sb = new StringBuilder();

            byte[] bytearray = Encoding.ASCII.GetBytes(data);

            foreach (byte bytepart in bytearray)
            {
                sb.Append(bytepart.ToString("X2"));
            }

            return sb.ToString().ToUpper();
        }


        /// <summary>
        /// Converts a Hexadecimal string to ASCII string
        /// </summary>
        /// <param name="hexString">Hexadecimal string</param>
        /// <returns>ASCII string</returns>
        public static string HexToString(string hexString)
        {
            if (hexString == null || (hexString.Length & 1) == 1)
            {
                throw new ArgumentException();
            }
            var sb = new StringBuilder();
            for (var i = 0; i < hexString.Length; i += 2)
            {
                var hexChar = hexString.Substring(i, 2);
                sb.Append((char)Convert.ToByte(hexChar, 16));
            }
            return sb.ToString();
        }

        /// <summary>
        /// Encodes a String to a Base64 String
        /// </summary>
        /// <param name="data">String data</param>
        /// <returns>Base64 Encoded String</returns>
        public static string StringToBase64(string data)
        {
            byte[] bytearray = Encoding.ASCII.GetBytes(data);

            string result = Convert.ToBase64String(bytearray);

            return result;
        }

        /// <summary>
        /// Converts a Base64 string to decoded String
        /// </summary>
        /// <param name="base64String">Base64 encoded string</param>
        /// <returns>Decoded String from Base64</returns>
        public static string Base64ToString(string base64String)
        {
            byte[] bytearray = Convert.FromBase64String(base64String);

            using (var ms = new MemoryStream(bytearray))
            {
                using (StreamReader reader = new StreamReader(ms))
                {
                    string text = reader.ReadToEnd();
                    return text;
                }
            }
        }


        /// <summary>
        /// Encodes a Number to a Base64 String
        /// https://ideone.com/q8wkgt
        /// </summary>
        /// <param name="data">Long number data</param>
        /// <returns>Base64 Encoded String</returns>
        public static string NumberToBase64(long data)
        {
            string result = Convert.ToBase64String(BitConverter.GetBytes(data));
            return result;
        }

        /// <summary>
        /// Encodes a Base64 String back to a Number
        /// https://ideone.com/q8wkgt
        /// </summary>
        /// <param name="data">String data</param>
        /// <returns>Long number</returns>
        public static long Base64ToNumber(string data)
        {
            long number = BitConverter.ToInt64(Convert.FromBase64String(data), 0);

            return number;
        }


    }
}
