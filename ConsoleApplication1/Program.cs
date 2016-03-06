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
        static void Main(string[] args)
        {
            /*Console.Write("Enter strength: ");
            int str = int.Parse(Console.ReadLine());
            Console.WriteLine("Key strength = " + KeyGeneration(str) + "bits");
            StreamReader objReader = new StreamReader(@"C:\Users\Public\keys\test.txt");
            do
            {
                char[] l = objReader.ReadLine().ToCharArray();
                foreach (char c in l) { Console.Write(Convert.ToInt32(c)); }
                Console.WriteLine();
            } while (objReader.Peek() != -1);
            objReader.Close();*/
            string[] x = { "are", "hfdifhg", "dfkhgkdjf" };
            Console.WriteLine(string.Join("", x).Substring(0,3));
            Console.ReadLine();
        }

    }
}
