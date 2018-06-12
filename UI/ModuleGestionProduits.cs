using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using LocaMat.Metier;
using LocaMat.UI.Framework;


namespace LocaMat.UI
{
    public class ModuleGestionProduits
    {
        private Menu menu;

        private void InitialiserMenu()
        {
            this.menu = new Menu("Gestion des produits");
            this.menu.AjouterElement(new ElementMenu("1", "Afficher les produits")
            {
                FonctionAExecuter = this.AfficherProduits
            });
            this.menu.AjouterElement(new ElementMenu("2", "Ajouter un produit")
            {
                FonctionAExecuter = this.AjouterProduit
            });
            this.menu.AjouterElement(new ElementMenuQuitterMenu("R", "Revenir au menu principal..."));
        }

        public void Demarrer()
        {
            if (this.menu == null)
            {
                this.InitialiserMenu();
            }

            this.menu.Afficher();
        }

        private void AfficherProduits()
        {
            ConsoleHelper.AfficherEntete("Produits");
            {
                var connectionString = ConfigurationManager.ConnectionStrings["Connexion"].ConnectionString;
                var connexion = new SqlConnection(connectionString);
                var commande = new SqlCommand("SELECT * FROM Produits", connexion);
                connexion.Open();
                SqlDataReader dataReader = commande.ExecuteReader();
                while (dataReader.Read())
                {
                    Console.WriteLine($"Id:{dataReader.GetInt32(0)}, Nom: {dataReader.GetString(1)} , Description: {dataReader.GetString(2).Tronquer(15)}, IdCategorie: {dataReader.GetInt32(3)}, PrixJourHT: {dataReader.GetDecimal(4)}");
                }

                connexion.Close();
            }
            
            //ConsoleHelper.AfficherListe(liste);
        }

        private void AjouterProduit()
        {
            ConsoleHelper.AfficherEntete("Nouveau produit");

            Console.WriteLine("Entrer le Nom du produit: ");
            var nomProduit = Console.ReadLine();

            Console.WriteLine("Entrer la description du produit: ");
            var descriptionProduit = Console.ReadLine();

            AfficherCategoriesProduits();

            Console.WriteLine("Choisir la categorie du produit: ");
            var categorieProduit = Console.ReadLine();

            Console.WriteLine("Entrer le prix du produit: ");
            var prixProduit = Decimal.Parse(Console.ReadLine());

            var connectionString = ConfigurationManager.ConnectionStrings["Connexion"].ConnectionString;

            using (var connexion = new SqlConnection(connectionString))
            {

                //Creation d'une commande SQL
                var sql = "INSERT INTO Produits (Nom, Description, IdCategorie, PrixJourHT) VALUES (@Nom, @Description, @IdCategorie, @PrixJourHT)";
                var commande = new SqlCommand(sql, connexion);
                commande.Parameters.Add(new SqlParameter
                {
                    ParameterName = "Nom",
                    Value = nomProduit
                });

                commande.Parameters.Add(new SqlParameter
                {
                    ParameterName = "Description",
                    Value = descriptionProduit
                });

                commande.Parameters.Add(new SqlParameter
                {
                    ParameterName = "IdCategorie",
                    Value = categorieProduit
                });

                commande.Parameters.Add(new SqlParameter
                {
                    ParameterName = "PrixJourHT",
                    Value = prixProduit

                });

                connexion.Open();
                commande.ExecuteNonQuery();
                connexion.Close();
            }
        }

            private void AfficherCategoriesProduits()
            {
                {
                    var connectionString = ConfigurationManager.ConnectionStrings["Connexion"].ConnectionString;
                    var connexion = new SqlConnection(connectionString);
                    var commande = new SqlCommand("SELECT * FROM CategoriesProduits", connexion);
                    connexion.Open();
                    SqlDataReader dataReader = commande.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Console.WriteLine($"Id:{dataReader.GetInt32(0)}, Nom: {dataReader.GetString(1)}") ;
                    }

                    connexion.Close();
                }

                //ConsoleHelper.AfficherListe(liste);
            }
        }

    public static class ExtensionsString
    {
        public static string Tronquer (this string valeur, int nombreCaracteres)
        {
            const string points = "...";
            return string.IsNullOrEmpty(valeur) || valeur.Length <= nombreCaracteres
                ? valeur
                : valeur.Substring(0, nombreCaracteres - points.Length) + points;
        }
    }
    }






