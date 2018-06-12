using System;
using System.Collections.Generic;
using System.Linq;
using LocaMat.UI.Framework;

namespace LocaMat.UI
{
    internal static class ConsoleHelper
    {
        public static void AfficherEntete(string libelle)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGray;

            // Comme j'utilise "| " et " |", la ligne doit avoir 6 caractères en plus
            var ligneTraits = new string('*', libelle.Length + 6);
            Console.WriteLine(ligneTraits);
            Console.WriteLine($"|  { libelle.ToUpper() }  |");
            Console.WriteLine(ligneTraits);
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public static void AfficherLignePourRetournerAuMenu()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("> Appuyez sur une touche pour retourner au menu...");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.ReadKey();
        }

        public static void AfficherVotreChoix()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();
            Console.Write("> Votre choix : ");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public static void EffacerLignesConsole(int nombreLignes = 1)
        {
            for (int i = 1; i <= nombreLignes; i++)
            {
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, Console.CursorTop - 1);
            }
        }

        public static void AfficherMessageErreur(string message)
        {
            EffacerLignesConsole(1);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(message);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public static void AfficherLibelleSaisie(string libelle)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();
            Console.WriteLine(libelle);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public static void AfficherListe<T>(IEnumerable<T> liste)
        {
            // Par réflexion, on récupère les propriétés de la classe qui ont l'attribut InformationAffichage
            var type = typeof(T);
            var proprietesAvecInformationAffichage = type.GetProperties()
                .Where(x => x.CustomAttributes
                .Any(y => y.AttributeType == typeof(InformationAffichageAttribute)))
                .ToList();

            if (!proprietesAvecInformationAffichage.Any())
            {
                Console.WriteLine("Rien à afficher...");
            }

            // On construit un tableau avec 
            //  - en première ligne les entêtes,
            //  - en deuxième ligne les séparateurs,
            //  - ensuite les éléments de la liste
            var contenu = new string[liste.Count() + 2, proprietesAvecInformationAffichage.Count()];

            for (int i = 0; i < proprietesAvecInformationAffichage.Count; i++)
            {
                var propriete = proprietesAvecInformationAffichage[i];
                var informationAffichage = propriete.GetCustomAttributes(false).OfType<InformationAffichageAttribute>().SingleOrDefault();
                var nombreCaracteres = informationAffichage.NombreCaracteres;

                // Ligne d'en-tête
                contenu[0, i] = informationAffichage.Entete.ToUpper().PadRight(nombreCaracteres) + " ";

                // Ligne de séparation
                contenu[1, i] = new string('-', nombreCaracteres + 1);

                // Eléments de la liste
                for (var j = 0; j < liste.Count(); j++)
                {
                    var element = liste.ElementAt(j);

                    string renduValeur = string.Empty;
                    var valeur = propriete.GetValue(element);
                    if (valeur != null)
                    {
                        if (valeur is DateTime date)
                        {
                            renduValeur = date.ToShortDateString();
                        }
                        else
                        {
                            renduValeur = valeur.ToString().Tronquer(nombreCaracteres);
                        }
                    }

                    contenu[j + 2, i] = renduValeur.PadRight(nombreCaracteres) + " ";
                }
            }

            // Afficher le tableau
            for (int ligne = 0; ligne < liste.Count() + 2; ligne++)
            {
                for (var colonne = 0; colonne < proprietesAvecInformationAffichage.Count; colonne++)
                {
                    Console.Write(contenu[ligne, colonne]);
                }

                Console.WriteLine();
            }
        }
    }
}
