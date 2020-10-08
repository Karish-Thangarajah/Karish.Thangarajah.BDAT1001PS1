
using ConverterApp.Models;
using System;
using System.Text;

namespace ConverterApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please type your full name: ");
            var fullname = Console.ReadLine();

            string binaryFullName = Converter.StringToBinary2(fullname);

            Console.WriteLine($"Your full name converted to binary is {binaryFullName} \n");

            var binaryName = Console.ReadLine();

            string ascii = Converter.BinaryToString(binaryName);

            Console.WriteLine($"Your binary string converted to ascii is {ascii} \n");

            byte[] fullNameBytes = Encoding.ASCII.GetBytes(fullname);

            int[] key = new int[20];



            for (int i = 0; i < key.Length; i++)
            {
                if (i < fullNameBytes.Length)
                {

                    key[i] = fullNameBytes[i];
                }
                else
                {
                    key[i] = i;
                }
            }

            string encryptedName = Encrypter.DeepEncryptWithCipher(ascii, key, 20);
            string decryptedName = Encrypter.DeepDecryptWithCipher(encryptedName, key, 20);
            Console.WriteLine($"Your full name after being encrypted 20 times using the byte array form of your full name as a basis for the key is \n {encryptedName} \n");
            Console.WriteLine($"Your encrypted name after being decrypted 20 times using the byte array form of your full name as a basis for the key is \n {decryptedName}");
        }
    }
}
