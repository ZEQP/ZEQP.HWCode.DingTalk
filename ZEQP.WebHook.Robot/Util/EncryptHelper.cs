using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ZEQP.WebHook.Robot
{
    public static class EncryptHelper
    {
        public static byte[] ToHMACSHA256(this string srcString, string secret)
        {
            byte[] secrectKey = Encoding.UTF8.GetBytes(secret);
            using (HMACSHA256 hmac = new HMACSHA256(secrectKey))
            {
                hmac.Initialize();
                byte[] bytes_hmac_in = Encoding.UTF8.GetBytes(srcString);
                byte[] bytes_hamc_out = hmac.ComputeHash(bytes_hmac_in);
                return bytes_hamc_out;
            }
        }
        public static string ToBase64(this byte[] src)
        {
            return Convert.ToBase64String(src);
        }
        public static string ToBase64(this string srcString)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(srcString));
        }
        public static string ToBase64(this string srcString, Encoding encoding)
        {
            return Convert.ToBase64String(encoding.GetBytes(srcString));
        }
    }
}
