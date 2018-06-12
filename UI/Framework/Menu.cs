using System;
using System.Collections.Generic;
using System.Linq;

namespace LocaMat.UI.Framework
{
    public class Menu
    {
        private readonly List<ElementMenu> elements = new List<ElementMenu>();

        public Menu(string libelle)
        {
            this.Libelle = libelle;
        }

        public string Libelle { get; }

        public void Afficher()
        {
            while (true)
            {
                ConsoleHelper.AfficherEntete(this.Libelle);

                foreach (var element in this.elements)
                {
                    element.Afficher();
                }

                ConsoleHelper.AfficherVotreChoix();

                ElementMenu elementCorrespondant;
                do
                {
                    var retour = Console.ReadKey();
                    elementCorrespondant = this.elements.FirstOrDefault(x => x.Correspondre(retour.KeyChar.ToString()));
                } while (elementCorrespondant == null);

                elementCorrespondant.Executer();
                if (elementCorrespondant is ElementMenuQuitterMenu)
                {
                    break;
                }
            }
        }

        public void AjouterElement(ElementMenu element)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element), "L'élément à ajouter ne peut pas être null");
            }

            if (this.elements.Any(x => x.Commande == element.Commande))
            {
                throw new InvalidOperationException(
                    $"Il y a déjà un élément de menu avec la commande {element.Commande}"); 
            }

            this.elements.Add(element);
        }
    }
}
