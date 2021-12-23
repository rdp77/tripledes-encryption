using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace _3DESEncrypt
{
    public class TripleDES
    {
        private TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();

        public TripleDES(string key)
        {
            des.Key = UTF8Encoding.UTF8.GetBytes(key);
            des.Mode = CipherMode.ECB;
            des.Padding = PaddingMode.PKCS7;            
        }

        public void EncryptFile(string filepath)
        {
            byte[] Bytes = File.ReadAllBytes(filepath);
            byte[] eBytes = des.CreateEncryptor().TransformFinalBlock(Bytes, 0, Bytes.Length);
            File.WriteAllBytes(filepath, eBytes);
        }

        public void DecryptFile(string filepath)
        {
            byte[] Bytes = File.ReadAllBytes(filepath);
            byte[] dBytes = des.CreateDecryptor().TransformFinalBlock(Bytes, 0, Bytes.Length);
            File.WriteAllBytes(filepath, dBytes);
        }
    }
}
