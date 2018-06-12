using System;

namespace LocaMat.UI
{
    public static class ConsoleSaisie
    {
        private const string MessagePourValeurObligatoire = "Valeur obligatoire. Veuillez recommencer: ";
        private const string MessagePourValeurInvalide = "Valeur invalide. Veuillez recommencer: ";

        public static string SaisirChaine(string libelle, bool autoriserAucuneValeur)
        {
            ConsoleHelper.AfficherLibelleSaisie(libelle);

            var saisie = Console.ReadLine();

            while (string.IsNullOrEmpty(saisie) && !autoriserAucuneValeur)
            {
                ConsoleHelper.AfficherMessageErreur(MessagePourValeurObligatoire);
                saisie = Console.ReadLine();
            }

            return saisie;
        }

        public static DateTime SaisirDateObligatoire(string libelle)
        {
            ConsoleHelper.AfficherLibelleSaisie(libelle);

            bool estSaisieValide = false;
            DateTime date = default(DateTime);

            do
            {
                var saisie = Console.ReadLine();
                if (string.IsNullOrEmpty(saisie))
                {
                    ConsoleHelper.AfficherMessageErreur(MessagePourValeurObligatoire);
                }
                else
                {
                    estSaisieValide = DateTime.TryParse(saisie, out date);
                    if (!estSaisieValide)
                    {
                        ConsoleHelper.AfficherMessageErreur(MessagePourValeurInvalide);
                    }
                }
            } while (!estSaisieValide);

            return date;
        }

        public static DateTime? SaisirDateOptionnelle(string libelle)
        {
            ConsoleHelper.AfficherLibelleSaisie(libelle);

            bool estSaisieValide;
            DateTime? valeur = null;
            do
            {
                var saisie = Console.ReadLine();
                if (string.IsNullOrEmpty(saisie))
                {
                    valeur = null;
                    break;
                }

                estSaisieValide = DateTime.TryParse(saisie, out DateTime date);
                if (estSaisieValide)
                {
                    valeur = date;
                }
                else
                {
                    ConsoleHelper.AfficherMessageErreur(MessagePourValeurInvalide);
                }
            } while (!estSaisieValide);

            return valeur;
        }

        public static int SaisirEntierObligatoire(string libelle)
        {
            ConsoleHelper.AfficherLibelleSaisie(libelle);

            bool estSaisieValide = false;
            int valeur = default(int);

            do
            {
                var saisie = Console.ReadLine();
                if (string.IsNullOrEmpty(saisie))
                {
                    ConsoleHelper.AfficherMessageErreur(MessagePourValeurObligatoire);
                }
                else
                {
                    estSaisieValide = int.TryParse(saisie, out valeur);
                    if (!estSaisieValide)
                    {
                        ConsoleHelper.AfficherMessageErreur(MessagePourValeurInvalide);
                    }
                }
            } while (!estSaisieValide);

            return valeur;
        }

        public static int? SaisirEntierOptionnel(string libelle)
        {
            ConsoleHelper.AfficherLibelleSaisie(libelle);

            bool estSaisieValide;
            int? valeur = null;
            do
            {
                var saisie = Console.ReadLine();
                if (string.IsNullOrEmpty(saisie))
                {
                    valeur = null;
                    break;
                }

                estSaisieValide = int.TryParse(saisie, out int integer);
                if (estSaisieValide)
                {
                    valeur = integer;
                }
                else
                {
                    ConsoleHelper.AfficherMessageErreur(MessagePourValeurInvalide);
                }
            } while (!estSaisieValide);

            return valeur;
        }

        public static decimal SaisirDecimalObligatoire(string libelle)
        {
            ConsoleHelper.AfficherLibelleSaisie(libelle);

            bool estSaisieValide = false;
            decimal valeur = default(decimal);

            do
            {
                var saisie = Console.ReadLine();
                if (string.IsNullOrEmpty(saisie))
                {
                    ConsoleHelper.AfficherMessageErreur(MessagePourValeurObligatoire);
                }
                else
                {
                    estSaisieValide = decimal.TryParse(saisie.Replace(".", ","), out valeur);
                    if (!estSaisieValide)
                    {
                        ConsoleHelper.AfficherMessageErreur(MessagePourValeurInvalide);
                    }
                }
            } while (!estSaisieValide);

            return valeur;
        }

        public static decimal? SaisirDecimalOptionnel(string libelle)
        {
            ConsoleHelper.AfficherLibelleSaisie(libelle);

            bool estSaisieValide;
            decimal? valeur = null;
            do
            {
                var saisie = Console.ReadLine();
                if (string.IsNullOrEmpty(saisie))
                {
                    valeur = null;
                    break;
                }

                estSaisieValide = decimal.TryParse(saisie.Replace(".", ","), out decimal number);
                if (estSaisieValide)
                {
                    valeur = number;
                }
                else
                {
                    ConsoleHelper.AfficherMessageErreur(MessagePourValeurInvalide);
                }
            } while (!estSaisieValide);

            return valeur;
        }
    }
}
