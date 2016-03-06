using System;
using System.Collections;
using System.Text;
using System.Numerics;
using System.IO;

namespace RSA
{
    class Program
    {
        static double KeyGeneration(int strength)
        {
            Console.WriteLine("Starting key generation...");
            Key k = new Key(strength);
            k.pGen();
            Console.WriteLine("First prime generated.");
            k.qGen();
            Console.WriteLine("Second prime generated.");
            k.nGen();
            k.dGen();
            k.PublicKeyGen();
            k.PrivateKeyGen();
            k.SaveKey();
            Console.WriteLine("Key Generation Completed");
            return k.key_length;
        }
        static void Encryption(string key_file, string filepath)
        {
            Encrypt E = new Encrypt(key_file, filepath);
            E.EncryptFile();
        }
        static void Main(string[] args)
        {
            //KeyGeneration(32);
            Encryption(@"C:\Users\Public\keys\32_20160306223259.key", @"C:\Users\Public\keys\test.txt");
            Console.WriteLine("Encryption Complete.");
            Console.ReadLine();
        }

    }
}
