using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.IO;
using System.Security.AccessControl;

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
        public BigInteger phi_n;
        public double key_length;
        public BigInteger e = new BigInteger(65537);
        private BigInteger d;
        public PublicKey publickey;
        public PrivateKey privatekey;

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
        private BigInteger ModInv(BigInteger u, BigInteger v)
        {
            BigInteger inv, u1, u3, v1, v3, t1, t3, q;
            int iter;
            u1 = 1;
            u3 = u;
            v1 = 0;
            v3 = v;
            iter = 1;
            while (v3 != 0)
            {
                q = u3 / v3;
                t3 = u3 % v3;
                t1 = u1 + q * v1;
                u1 = v1; v1 = t1; u3 = v3; v3 = t3;
                iter = -iter;
            }
            if (u3 != 1) { return 0; }
            if (iter < 0) { inv = v - u1; }
            else { inv = u1; }
            return inv;
        }
        public void dGen() { this.d = ModInv(this.e, phi_n); }
        public void PublicKeyGen() { this.publickey = new PublicKey(n, e); }
        public void PrivateKeyGen() { this.privatekey = new PrivateKey(n, d); }
        private string getDateTime() { return DateTime.Now.ToString("yyyyMMddHHmmss"); }
        public void SaveKey()
        {
            string path = "C:\\Users\\Public\\keys";
            if (Directory.Exists(path) == false)
            {
                DirectorySecurity securityRules = new DirectorySecurity();
                securityRules.AddAccessRule(new FileSystemAccessRule(@"David", FileSystemRights.FullControl, AccessControlType.Allow));
                Directory.CreateDirectory(path, securityRules);
            }
            string filepath = path + @"\" + string.Concat(this.strength) + "_" + getDateTime()+".txt";
            using (StreamWriter file = new StreamWriter(@"C:\Users\Public\key.txt"))
            {
                file.WriteLine(publickey.n.ToString());
                file.WriteLine(publickey.e.ToString());
                file.WriteLine(privatekey.d.ToString());
            }
        }
    }
}
