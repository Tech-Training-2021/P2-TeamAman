using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2_WorldTrainer.Common
{
    public class Encryption
    {
        public string EncryptPassword(string pass)
        {
            try
            {
                byte[] b = System.Text.ASCIIEncoding.ASCII.GetBytes(pass);
                string encrypted = Convert.ToBase64String(b);
                return encrypted;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }

        }
        public string DecryptPassword(string pass)
        {
            try
            {
                byte[] b;
                string decrypted;
                b = Convert.FromBase64String(pass);
                decrypted = System.Text.ASCIIEncoding.ASCII.GetString(b);
                return decrypted;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }

        }

    }
}
