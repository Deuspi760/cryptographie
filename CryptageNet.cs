using System;
using System.Security.Cryptography;
using System.Text;

namespace CryptoGraphie
{
    // La classe CryptageNet propose des méthodes pour crypter et décrypter des messages en utilisant le chiffrement TripleDES
    class CryptageNet
    {
        // Clé de hachage utilisée pour le chiffrement
        private string hash = "hash";

        // Méthode pour crypter un message en utilisant le chiffrement TripleDES
        public string Crypter(string message)
        {
            string result = "";

            // Conversion du message en tableau de bytes en utilisant l'encodage UTF-8
            byte[] data = UTF8Encoding.UTF8.GetBytes(message);

            // Création d'une instance de MD5 pour obtenir une clé à partir de la clé de hachage
            using (MD5CryptoServiceProvider mD5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = mD5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));

                // Création d'une instance de TripleDESCryptoServiceProvider avec la clé obtenue
                using (TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    // Création d'un transformateur de chiffrement et application sur les données
                    ICryptoTransform transform = tripleDES.CreateEncryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);

                    // Conversion du résultat en Base64 pour stockage ou transmission
                    result = Convert.ToBase64String(results, 0, results.Length);
                }
            }
            return result;
        }

        // Méthode pour décrypter un message crypté en utilisant le chiffrement TripleDES
        public string Decrypter(string messageCrypte)
        {
            string result = "";

            // Conversion du message crypté de Base64 en tableau de bytes
            byte[] data = Convert.FromBase64String(messageCrypte);

            // Création d'une instance de MD5 pour obtenir une clé à partir de la clé de hachage
            using (MD5CryptoServiceProvider mD5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = mD5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));

                // Création d'une instance de TripleDESCryptoServiceProvider avec la clé obtenue
                using (TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    // Création d'un transformateur de déchiffrement et application sur les données
                    ICryptoTransform transform = tripleDES.CreateDecryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);

                    // Conversion du résultat en UTF-8 pour obtenir le message original
                    result = UTF8Encoding.UTF8.GetString(results);
                }
            }
            return result;
        }
    }
}
