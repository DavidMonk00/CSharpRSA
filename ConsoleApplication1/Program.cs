using System;
using System.Collections;
using System.Text;
using System.Numerics;

namespace RSA
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 5; i < 35 ; i++)
            {
                if (PrimeCheck.Check(new BigInteger(Math.Pow(2, i)-1)))
                {
                    Console.WriteLine(Math.Pow(2, i)-1);
                }
            }
            //Console.ReadLine();
        }
    }
}
