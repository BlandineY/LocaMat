using LocaMat.UI.Framework;

namespace LocaMat.Metier
{
    public class Agence
    {
        [InformationAffichage(Entete = "Id", NombreCaracteres = 3)]
        public int Id { get; set; }

        [InformationAffichage(Entete = "Ville", NombreCaracteres = 20)]
        public string Ville { get; set; }

        [InformationAffichage(Entete = "Adresse", NombreCaracteres = 50)]
        public string Adresse { get; set; }

        public override string ToString()
        {
            return this.Ville;
        }
    }
}
