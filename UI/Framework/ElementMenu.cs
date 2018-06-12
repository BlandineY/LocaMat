using System;

namespace LocaMat.UI.Framework
{
    public class ElementMenu
    {
        public ElementMenu(string commande, string libelle)
        {
            this.Commande = commande ?? throw new ArgumentNullException(nameof(commande));
            this.Libelle = libelle ?? throw new ArgumentNullException(nameof(libelle));
        }

        public string Libelle { get; }

        public string Commande { get; }

        public Action FonctionAExecuter { get; set; }

        public bool AfficherLigneRetourMenuApresExecution { get; set; } = true;

        public bool Correspondre(string valeur)
        {
            return this.Commande.Equals(valeur, StringComparison.OrdinalIgnoreCase);
        }

        public virtual void Afficher()
        {
            Console.WriteLine($"{this.Commande} - {this.Libelle}");
        }

        public virtual void Executer()
        {
            ConsoleHelper.AfficherEntete(this.Libelle);
            this.FonctionAExecuter();

            if (this.AfficherLigneRetourMenuApresExecution)
            {
                ConsoleHelper.AfficherLignePourRetournerAuMenu();
            }
        }
    }

    public sealed class ElementMenuQuitterMenu : ElementMenu
    {
        public ElementMenuQuitterMenu(string commande, string libelle)
            : base(commande, libelle)
        {
            this.AfficherLigneRetourMenuApresExecution = false;
        }

        public override void Afficher()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine();
            Console.WriteLine($"Tapez {this.Commande} pour {this.Libelle}");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public override void Executer()
        {
            // On ne veut ni d'en-tête ni de ligne de retour
            this.FonctionAExecuter?.Invoke();
        }
    }
}
