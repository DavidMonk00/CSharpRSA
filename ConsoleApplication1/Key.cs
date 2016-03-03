using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace RSA
{
    public class Key
    {
        private int strength;
        private BigInteger start;
        private BigInteger start_second;
        private BigInteger p;
        private BigInteger q;
        private BigInteger n;
        private BigInteger phi_n;
        public int key_length;
        private BigInteger e = new BigInteger(65537);
        private BigInteger d;
        //public PublicKey pubkey;

    }
}
