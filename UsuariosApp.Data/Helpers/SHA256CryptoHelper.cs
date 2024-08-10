﻿using System;
using System.Security.Cryptography;
using System.Text;

namespace UsuariosApp.Data.Helpers
{
    public class SHA256CryptoHelper
    {
        public static string ComputeHash(string input)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));                
                var builder = new StringBuilder();

                foreach (var b in bytes)
                    builder.Append(b.ToString("x2"));

                return builder.ToString();
            }
        }
    }
}
