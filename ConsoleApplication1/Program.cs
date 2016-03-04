using System;
using System.Collections;
using System.Text;
using System.Numerics;
using System.IO;

namespace RSA
{
    class Program
    {
        public static void Read()
        {
            try
            {
                using (StreamReader sr = new StreamReader(@"C:\Users\Public\test.txt"))
                {
                    string line = sr.ReadToEnd();
                    Console.WriteLine(line);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("This file could not be read:");
                Console.WriteLine(e.Message);
            }
        }
        static void Main(string[] args)
        {
            for (int i = 5; i < 15 ; i++)
            {
                if (PrimeCheck.Check(new BigInteger(Math.Pow(2, i)-1)))
                {
                    Console.WriteLine(Math.Pow(2, i)-1);
                }
            }
            Key k = new Key(10);
            k.pGen();
            k.qGen();
            k.nGen();
            k.dGen();
            k.PublicKeyGen();
            k.PrivateKeyGen();
            k.SaveKey();
            Console.ReadLine();
        }

    }
}
