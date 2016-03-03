using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace RSA
{
    class PrimeCheck
    {
        public static BigInteger sqrt(BigInteger n)
        {
            BigInteger a = new BigInteger(1);
            BigInteger b = (n >> 5) + new BigInteger(8);
            while (b.CompareTo(a) >= 0)
            {
                BigInteger mid = (a + b) >> 1;
                if ((mid* mid).CompareTo(n) > 0) { b = mid - new BigInteger(1); }
                else { a = mid + new BigInteger(1); }
            }
            return a;
        }
        public static bool Check(BigInteger x)
        {
            if (x % new BigInteger(2) == 0)
            {
                return false;
            }
            else
            {
                bool isPrime = true;
                for (BigInteger i = new BigInteger(3); i.CompareTo(sqrt(x)) < 0; i = i + new BigInteger(1))
                {
                    if (x % i == 0)
                    {
                        isPrime = false;
                    }
                }
                if (isPrime) { return true; }
                else { return false; }
            }
        }
    }
}
