using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace RSA
{
    public class PublicKey
    {
        public BigInteger n;
        public BigInteger e;
        public PublicKey(BigInteger n, BigInteger e)
        {
            this.n = n;
            this.e = e;
        }
    }
}
