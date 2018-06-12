using LocaMat.UI.Framework;

namespace LocaMat.Metier
{
    public class Client
    {
        [InformationAffichage(Entete = "Id", NombreCaracteres = 3)]
        public int Id { get; set; }

        [InformationAffichage(Entete = "Nom", NombreCaracteres = 20)]
        public string Nom { get; set; }

        [InformationAffichage(Entete = "Prénom", NombreCaracteres = 20)]
        public string Prenom { get; set; }

        [InformationAffichage(Entete = "Adresse", NombreCaracteres = 50)]
        public string Adresse { get; set; }

        public override string ToString()
        {
            return $"{this.Nom.ToUpper()} {this.Prenom}";
        }
    }
}
