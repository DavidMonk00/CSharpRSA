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
        public double key_length;
        private BigInteger e = new BigInteger(65537);
        private BigInteger d;
        public PublicKey publickey;
        public PrivateKey privatekey;
        String filepath;

        public Key(int exp)
        {
            this.strength = exp;
            this.start = BigInteger.Pow(new BigInteger(2), exp) + new BigInteger(new Random().Next(10000));
            this.start_second = this.start + BigInteger.Pow(new BigInteger(2), exp - 2);
        }
        public void pGen() { this.p = PrimeGen.Gen(this.start); }
        public void qGen() { this.q = PrimeGen.Gen(this.start_second); }
        public void nGen()
        {
            this.n = this.p * this.q;
            this.phi_n = this.n - (this.p + this.q - new BigInteger(1));
            this.key_length = Math.Ceiling(BigInteger.Log(this.n, 2));
        }
        public void dGen() { this.d = BigInteger.ModPow(this.e , -1, phi_n); }
        public void PublicKeyGen() { this.publickey = new PublicKey(n, e); }
        public void PrivateKeyGen() { this.privatekey = new PrivateKey(n, d); }
    }
}
