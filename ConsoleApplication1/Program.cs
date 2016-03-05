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
            Key k = new Key(32);
            k.pGen();
            k.qGen();
            k.nGen();
            Console.WriteLine("phi_n = " + k.phi_n);
            k.dGen();
            k.PublicKeyGen();
            k.PrivateKeyGen();
            //k.SaveKey();
            Console.ReadLine();
        }

    }
}
