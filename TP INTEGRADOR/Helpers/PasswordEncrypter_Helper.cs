using System.Security.Cryptography;
using System.Text;

namespace TP_INTEGRADOR.Helpers
{
    public static class PasswordEncrypter_Helper
    {
        public static string EncryptPassword(string password, int userDNI = 0)
        {
            string saltedPassword = String.Concat(password, GenerateSalt(userDNI));

            var sha256 = SHA256.Create();
            var sb = new StringBuilder();

            var stream = sha256.ComputeHash(Encoding.UTF8.GetBytes(saltedPassword)); //stream = array de bytes.

            for (int i = 0; i < stream.Length; i++)
            {
                sb = sb.AppendFormat("{0:x2}", stream[i]);
            }

            return sb.ToString();
        }

        private static string GenerateSalt(int userDNI)
        {
            byte[] saltBytes = Encoding.ASCII.GetBytes(userDNI.ToString());
            string saltString;
            long xored = 0x00;

            foreach(byte bite in saltBytes)
            {
                xored = xored ^ bite;
            }

            Random random = new Random(Convert.ToInt32(xored));

            saltString = random.Next().ToString();
            saltString += random.Next().ToString();
            saltString += random.Next().ToString();
            saltString += random.Next().ToString();

            return saltString;
        }
    }
}
