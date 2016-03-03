using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace RSA
{
    class PrimeGen
    {
        public static BigInteger Gen(BigInteger start)
        {
            if (start % new BigInteger(2) == 0) { start = start + new BigInteger(1); }
            bool prime_bool = false;
            BigInteger prime = new BigInteger(0);
            while(prime_bool == false)
            {
                prime_bool = PrimeCheck.Check(start);
                if (prime_bool) { prime = start; }
                start = start + new BigInteger(2);
            }
            return prime;
        }
    }
}
