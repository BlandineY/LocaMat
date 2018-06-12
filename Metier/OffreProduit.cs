using LocaMat.UI.Framework;

namespace LocaMat.Metier
{
    public class OffreProduit
    {
        [InformationAffichage(Entete = "Id", NombreCaracteres = 3)]
        public int Id { get; set; }

        [InformationAffichage(Entete = "Produit", NombreCaracteres = 30)]
        public Produit Produit { get; set; }
        public int IdProduit { get; set; }

        public int IdAgence { get; set; }

        [InformationAffichage(Entete = "Qté", NombreCaracteres = 3)]
        public int Quantite { get; set; }
    }
}
