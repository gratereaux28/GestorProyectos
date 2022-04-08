using GestorProyectos.Infrastructure.Interfaces;
using GestorProyectos.Infrastructure.Options;
using Microsoft.Extensions.Options;
using System.Security.Cryptography;
using System.Text;

namespace GestorProyectos.Infrastructure.Services
{
    public class PasswordService : IPasswordService
    {
        private readonly PasswordOptions _options;

        public PasswordService(IOptions<PasswordOptions> options)
        {
            _options = options.Value;
        }

        public bool Check(string hash, string password)
        {
            var parts = hash.Split('.');
            if (parts.Length != 3)
            {
                throw new FormatException("Unexpected hash format");
            }

            var iterations = Convert.ToInt32(parts[0]);
            var salt = Convert.FromBase64String(parts[1]);
            var key = Convert.FromBase64String(parts[2]);

            using (var algorithm = new Rfc2898DeriveBytes(
                password,
                salt,
                iterations
                ))
            {
                var keyToCheck = algorithm.GetBytes(32);
                return keyToCheck.SequenceEqual(key);
            }
        }

        public string UnHash(string decriptText)
        {
            var parts = decriptText.Split('.');
            decriptText = decriptText.Replace(" ", "+");
            byte[] bytesBuff = Convert.FromBase64String(decriptText);

            using (Aes aes = Aes.Create())
            {

                var iterations = Convert.ToInt32(parts[0]);
                var salt = Convert.FromBase64String(parts[1]);
                var key = Convert.FromBase64String(parts[2]);

                aes.Key = Convert.FromBase64String(Convert.ToBase64String(key));
                aes.IV = Convert.FromBase64String(Convert.ToBase64String(salt));

                using var mStream = new MemoryStream();
                using (var cStream = new CryptoStream(mStream, aes.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cStream.Write(bytesBuff, 0, bytesBuff.Length);
                    cStream.Close();
                }

                decriptText = Encoding.Unicode.GetString(mStream.ToArray());
            }

            return decriptText;
        }

        public string Hash(string password)
        {
            //PBKDF2 implementation
            using (var algorithm = new Rfc2898DeriveBytes(
                password,
                16,
                10000
                ))
            {
                var key = Convert.ToBase64String(algorithm.GetBytes(32));
                var salt = Convert.ToBase64String(algorithm.Salt);

                return $"{10000}.{salt}.{key}";
            }
        }
    }
}