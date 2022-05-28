using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.IO;

namespace eshop.Models
{
    public class eshopInitializer:DropCreateDatabaseIfModelChanges<eshopContext>
    {
        //l'intialisation de la base de donnée DbSet
        protected override void Seed(eshopContext context)
        {
            //pour executer la methode seed de la classe mere
            base.Seed(context);
            var productList = new List<Produit>
            {
                 new Produit
                 {
                     NomProduit="Iphone12",
                     Quantite=10,
                     Description="cest un telephone Iphone 12",
                     Prix=3000,
                     ProduitImage=getFileBytes("\\Images\\Imprimente.jpeg"),
                     ProduitImageType="image/jpeg",
                 },
                 new Produit
                 {
                     NomProduit="Lenovo",
                     Quantite=20,
                     Description="cest un pc lenovo",
                     Prix=4000,
                     ProduitImage=getFileBytes("\\Images\\Imprimente.jpeg"),
                     ProduitImageType="image/jpeg",
                 },
                 new Produit
                 {
                     NomProduit="Iprimante",
                     Quantite=30,
                     Description="cest un Iprimante just pour vous",
                     Prix=10000,
                     ProduitImage=getFileBytes("\\Images\\Imprimente.jpeg"),
                     ProduitImageType="image/jpeg",
                 }
            };
            //parcourir la list et pour chaque elementon va l'ajouter
            //le context la table produit que nous avons creé
            productList.ForEach(p => context.Produits.Add(p));
            context.SaveChanges();
            //nmxiw fichier Global.asax bach ndiro l'execution intializer(class eshopInitializer) 
        }
        //methode qui permet de recuperer les images à partir d'un chemein en url 
        private byte[] getFileBytes(string path)
        {
            FileStream fileOnDisk = new FileStream(HttpRuntime.AppDomainAppPath+path,FileMode.Open);
            byte[] fileBytes;
            using (BinaryReader br = new BinaryReader(fileOnDisk))
            {
                fileBytes = br.ReadBytes((int)fileOnDisk.Length);
            }
            return fileBytes;

        }
    }
}