﻿using GestorProyectos.Infrastructure.Interfaces;
using GestorProyectos.Infrastructure.Options;
using Microsoft.Extensions.Options;
using System.Security.Cryptography;

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