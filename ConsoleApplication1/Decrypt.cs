using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Numerics;

namespace RSA
{
    class Decrypt
    {
        string key_file;
        PrivateKey privatekey;
        string filepath;
        string[] m;
        string file_extension;
        private void GetKey()
        {
            string[] lines = File.ReadAllLines(this.key_file);
            this.privatekey = new PrivateKey(BigInteger.Parse(lines[0]), BigInteger.Parse(lines[2]);
        }
        public Decrypt(string filepath) { this.filepath = filepath; }
        private void DecryptLine(string line)
        {

        }
    }
}
