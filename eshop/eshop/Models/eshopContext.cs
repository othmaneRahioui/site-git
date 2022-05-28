using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace eshop.Models
{
    public class eshopContext:DbContext
    {
        //darna l'heritage dyal constructeur de la classe 
        //mere qui porte comme nom :le nom de la base de donnee
        public eshopContext() : base("name = eshopDB") { }
            //les tables de la base de donnee
            public DbSet<Produit> Produits { get; set; }
       
    }
}