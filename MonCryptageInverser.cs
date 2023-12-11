using System;
using System.Linq;

namespace CryptoGraphie
{
    // La classe MonCryptageInverser propose des méthodes pour crypter et décrypter des messages
    class MonCryptageInverser
    {
        private static Random random = new Random();
        private const string MotAleatoire = "You_Shell_Not_Pass";

        // Inversion du mot aléatoire pour utilisation dans le cryptage
        private string MotAleatoire_invers = new string(MotAleatoire.Reverse().ToArray());

        // Méthode pour crypter un message en inversant son contenu et en ajoutant un mot aléatoire
        public string Crypter(string message)
        {
            // Inversion du mot principal
            string motInverse = new string(message.Reverse().ToArray());

            // Ajout du mot aléatoire inversé
            string messageCrypte = motInverse + MotAleatoire_invers + GenererMotAleatoire();

            return messageCrypte;
        }

        // Méthode pour décrypter un message en extrayant le mot principal et en inversant son contenu
        public string Decrypter(string messageCrypte)
        {
            // Extraction du mot principal avant l'inversion
            string motPrincipal = ExtraireMotPrincipal(messageCrypte);

            // Inversion du mot principal
            string messageDecrypte = new string(motPrincipal.Reverse().ToArray());

            return messageDecrypte;
        }

        // Méthode privée pour extraire le mot principal d'un message crypté
        private string ExtraireMotPrincipal(string messageCrypte)
        {
            // Suppression du mot aléatoire inversé
            string messageSansMotAleatoire = messageCrypte.Replace(MotAleatoire_invers, "");

            // Extraction du mot principal (tout avant le mot aléatoire inversé)
            int indexMotAleatoire = messageCrypte.IndexOf(MotAleatoire_invers);
            if (indexMotAleatoire >= 0)
            {
                return messageSansMotAleatoire.Substring(0, indexMotAleatoire);
            }

            return messageSansMotAleatoire;
        }

        // Méthode privée pour générer un mot aléatoire de longueur 6 à partir d'un dictionnaire de caractères
        private string GenererMotAleatoire()
        {
            string dico = "ABCDEFGHJKLMNOPQRSTUVWXYZ";
            char[] chars = new char[6];
            Random rand = new Random();

            // Remplissage du tableau de caractères avec des caractères aléatoires du dictionnaire
            for (int i = 0; i < 6; i++)
            {
                chars[i] = dico[rand.Next(0, dico.Length)];
            }

            return new string(chars);
        }
    }
}
