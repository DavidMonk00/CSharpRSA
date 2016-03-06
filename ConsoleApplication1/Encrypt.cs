using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Numerics;

namespace RSA
{
    public class Encrypt
    {
        string key_file;
        PublicKey publickey;
        string filepath;
        public Encrypt(string key_file, string filepath)
        {
            this.key_file = key_file;
            string[] lines = File.ReadAllLines(key_file);
            this.publickey = new PublicKey(BigInteger.Parse(lines[0]), BigInteger.Parse(lines[1]));
            this.filepath = filepath;
        }
        private string EncryptLine(string line)
        {
            char[] char_array = line.ToCharArray();
            string[] int_array = new string[char_array.Length];
            for (int i = 0; i < char_array.Length; i++) { int_array[i] = ((int)char_array[i]).ToString("0000.##"); }
            string int_string = string.Join("", int_array);
            int n_length = publickey.n.ToString().Length - 2;
            int key_number = (int_string.Length + n_length - 1)/n_length;
            string[] c_line = new string[key_number];
            for (int i = 0; i < key_number; i++)
            {
                BigInteger m_line;
                int index = i * n_length;
                if (index + n_length < int_string.Length)
                {
                    m_line = BigInteger.Parse("1" + int_string.Substring(index, n_length));
                }
                else
                {
                    m_line = BigInteger.Parse("1" + int_string.Substring(index));
                }
                c_line[i] = string.Concat(BigInteger.ModPow(m_line, publickey.e, publickey.n));
            }
            return string.Join(" ", c_line);
        }
        public void EncryptFile()
        {
            string new_filepath = this.filepath.Split(".".ToCharArray()[0])[0] + ".encrypt";
            StreamWriter objWriter = new StreamWriter(new_filepath);
            StreamReader objReader = new StreamReader(this.filepath);
            objWriter.WriteLine(Path.GetExtension(this.filepath));
            objWriter.WriteLine(this.key_file);
            do
            {
                string c_line = EncryptLine(objReader.ReadLine());
                objWriter.WriteLine(c_line);
            } while (objReader.Peek() != -1);
            objReader.Close();
            objWriter.Close();
        }
    }
}
