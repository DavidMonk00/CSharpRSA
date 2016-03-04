using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace RSA
{
    public class PrivateKey
    {
        public BigInteger d;
        public BigInteger n;
        public PrivateKey(BigInteger n, BigInteger d)
        {
            this.n = n;
            this.d = d;
        }
    }
}
