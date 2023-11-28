using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesSystem.BLL.Interfaces;
using System.Security.Cryptography;

namespace SalesSystem.BLL.Implementations
{
    public class UtilityServices : IUtilityServices
    {

        public string PasswordGenerate()
        {
            string password = Guid.NewGuid().ToString("N").Substring(0, 6);
            return password;
        }

        public string Sha265Convertion(string text)
        {
            StringBuilder sb = new StringBuilder();
            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;

                byte[] result = hash.ComputeHash(enc.GetBytes(text));

                foreach (byte b in result)
                {
                    sb.Append(b.ToString("X2"));
                }
            }

            return sb.ToString();
        }
    }
}

