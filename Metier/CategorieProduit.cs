using LocaMat.UI.Framework;

namespace LocaMat.Metier
{
    public class CategorieProduit
    {
        [InformationAffichage(Entete = "Id", NombreCaracteres = 2)]
        public int Id { get; set; }

        [InformationAffichage(Entete = "Libelle", NombreCaracteres = 20)]
        public string Libelle { get; set; }

        public override string ToString()
        {
            return this.Libelle;
        }
    }
}
