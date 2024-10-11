using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Common.BusinessLogicLayer
{
    public class CommonServices
    {
        public  string DecryptString(string clearText, string key)
        {
            byte[] cipherBytes = Convert.FromBase64String(clearText);
            using (Aes decryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(key, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 }); decryptor.Key = pdb.GetBytes(32); decryptor.IV = pdb.GetBytes(16); using (MemoryStream ms = new MemoryStream(cipherBytes))
                {
                    using (CryptoStream cs = new CryptoStream(ms, decryptor.CreateDecryptor(), CryptoStreamMode.Read))
                    {
                        byte[] clearBytes = new byte[cipherBytes.Length];
                        int bytesDecrypted = cs.Read(clearBytes, 0, clearBytes.Length);
                        return Encoding.UTF8.GetString(clearBytes, 0, bytesDecrypted);

                    }
                }
            }
        }
        

    }
}
