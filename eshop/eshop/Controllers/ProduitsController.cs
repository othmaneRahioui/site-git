using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eshop.Models;
using System.Data.Entity;

namespace eshop.Controllers
{
    public class ProduitsController : Controller
    {
        eshopContext context = new eshopContext();
        // GET: Produits
       public ActionResult ListProduit()
        {
            return View("ListProduit()", context.Produits.ToList()) ;
        }
        public ActionResult AfficherProduit(int id)
        {
            Produit  p=new Produit();
            //pour trouver un produit
            p=context.Produits.Find(id);
            if (p != null)
                //return View("le nom de methode", parametres)
                return View("AfficherProduit()", p);
            else
                return HttpNotFound();
        }
        public ActionResult AjouterProduit()
        {
            Produit p=new Produit();
            return View("AjouterProduit", p);
        }
        [HttpPost]
        public ActionResult AjouterProduit(Produit p,HttpPostedFileBase image)
        {
            if(ModelState.IsValid)
            {
                if(image!=null)
                {
                    p.ProduitImageType = image.ContentType;
                    p.ProduitImage=new byte[image.ContentLength];
                    image.InputStream.Read(p.ProduitImage, 0, image.ContentLength);
                }
            context.Produits.Add(p);
            context.SaveChanges();
            return RedirectToAction("ListProduit");
            }
            else
                return View("AjouterProduit",p);
        }
        public ActionResult ListeSuppression()
        {
            return View(" ListeSuppression", context.Produits.ToList());
        }
        public ActionResult Supprimer(int id)
        {
            Produit p = new Produit();
            p = context.Produits.Find(id);
            if(p!=null)
                return View("Supprimer", p);
            else
                return HttpNotFound();
        }
        [HttpPost,ActionName("Supprimer")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmerSuppression(int id)
        {
            Produit p = new Produit();
            p = context.Produits.Find(id);
            if (p != null)
            {
                context.Produits.Remove(p);
                context.SaveChanges();
                return RedirectToAction("ListeSuppression");
            }
            else
                return HttpNotFound();
        }
        public ActionResult ListeModification()
        {
            return View("ListeModification", context.Produits.ToList());
        }
        public ActionResult Modifier(int id)
        {
            Produit p = new Produit();
            p = context.Produits.Find(id);
            if (p != null)
                return View("Modifier", p);
            else
                return HttpNotFound();
        }
        [HttpPost,ActionName("Modifier")]
        [ValidateAntiForgeryToken]
        //kandiro toujours had verification de dependence
        public ActionResult Modifier (Produit p)
        {
            if (ModelState.IsValid)
            {
                context.Entry(p).State = EntityState.Modified;
                context.SaveChanges();
                return View("ListProduit", context.Produits.ToList());
            }
            else
                return View("Modifier", p); 
        }
        public FileContentResult GetImage(int id)
        {
            Produit p = new Produit();
            p = context.Produits.Find(id);
            if (p != null)
                return File(p.ProduitImage, p.ProduitImageType);
            else
                return null;
        }
    }
}