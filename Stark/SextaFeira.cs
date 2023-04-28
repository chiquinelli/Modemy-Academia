using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using Microsoft.AspNetCore.WebUtilities;


namespace MuscleAcademia.Stark
{
    public class SextaFeira
    {
        public static string FormatarTelefone(string telefone)
        {
            if (!string.IsNullOrEmpty(telefone) && telefone.Length == 11)
            {
                return string.Format("{0:(##) #####-####}", double.Parse(telefone));
            }
            return telefone;
        }

        public static string FormatarCep(string cep)
        {
            if (!string.IsNullOrEmpty(cep) && cep.Length == 8)
            {
                return string.Format("{0:#####-###}", double.Parse(cep));
            }
            return cep;
        }

        private static readonly byte[] Key = Encoding.UTF8.GetBytes("1234567890123456"); // chave de 16 caracteres
        private static readonly byte[] IV = Encoding.UTF8.GetBytes("abcdefghijklmnop"); // vetor de inicialização de 16 caracteres

        public static string Encrypt(int id)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                byte[] idBytes = Encoding.UTF8.GetBytes(id.ToString());

                byte[] encryptedIdBytes = encryptor.TransformFinalBlock(idBytes, 0, idBytes.Length);

                return Convert.ToBase64String(encryptedIdBytes, Base64FormattingOptions.None);
            }
        }


        public static int Decrypt(string encryptedId)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Remova os espaços em branco da string criptografada
                encryptedId = encryptedId.Replace(" ", "+");

                byte[] encryptedIdBytes = Convert.FromBase64String(encryptedId);

                byte[] idBytes = decryptor.TransformFinalBlock(encryptedIdBytes, 0, encryptedIdBytes.Length);

                return int.Parse(Encoding.UTF8.GetString(idBytes));
            }
        }


    }
}