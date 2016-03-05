using System;
using System.Collections;
using System.Text;
using System.Numerics;
using System.IO;

namespace RSA
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter strength: ");
            int str = int.Parse(Console.ReadLine());
            Console.WriteLine("Starting key generation...");
            Key k = new Key(str);
            k.pGen();
            Console.WriteLine("First prime generated.");
            k.qGen();
            Console.WriteLine("Second prime generated.");
            k.nGen();
            Console.WriteLine("phi_n = " + k.phi_n);
            k.dGen();
            k.PublicKeyGen();
            k.PrivateKeyGen();
            k.SaveKey();
            Console.WriteLine("Key Generation Completed");
            Console.ReadLine();
        }

    }
}
