using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Deiba.Data;
using Deiba.Models;
using Deiba.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Deiba.Controllers
{
   //[Authorize(Policy="adminpolicy")]
    public class PanelController : Controller
    { 
         
        public IActionResult PanelManager([FromServices]DBDeiba dB)
        {
            ViewData["Barands"] = dB.Barands.ToList();
           

           
            return View();
        }

       

        public IActionResult Productconfirm(ProductViewModel model,[FromServices] DBDeiba dB )
        {
            Product a = new Product
            { 
                 Name=model.Name,
                 Price=model.Price,
                 Title=model.Title,
                 Barandid=model.Barandid
             };
            if(model.Img != null)
            {
                if (model.Img.Length < 5 * Math.Pow(1024, 2))
                {
                    byte[] b = new byte [model.Img.Length];
                    model.Img.OpenReadStream().Read(b, 0, b.Length);

                    a.Img = b;
                }
            }
            
            dB.Add(a);
            dB.SaveChanges();
           
            return RedirectToAction("PanelManager","Panel");
        } 
        public IActionResult InsertBarand()
        {
            return View();
        }
       
        public IActionResult Barandconfirm(BarandViewModel model,[FromServices]DBDeiba dB)
        {
            Barand b = new Barand
            {
                Name = model.Name
            };
            dB.Add(b);
            dB.SaveChanges();
            return RedirectToAction("InsertBarand","Panel");
        }

        public IActionResult Fileinsert()
        {
            return View();
        } 
        public IActionResult Fileconfirm(FileViewModel model,[FromServices]DBDeiba dB)
        {
            File file = new File
            {
                Name = model.Name
            };
            if (model.Listlaptop != null)
            {
                byte[] b = new byte[model.Listlaptop.Length];
                model.Listlaptop.OpenReadStream().Read(b, 0, b.Length);
                file.Listlaptop = b;
            }
            
            if (model.Listmobile != null)
            {
                byte[] a = new byte[model.Listmobile.Length];
                model.Listmobile.OpenReadStream().Read(a, 0, a.Length);
                file.Listmobile = a;
            }
            dB.Add(file);
            dB.SaveChanges();

            return RedirectToAction("Fileinsert","Panel");
        }
        public IActionResult Fileshow([FromServices] DBDeiba dB)
        {

            return View(dB.Files.ToList());
        }

        public IActionResult Lstproduct([FromServices]DBDeiba dB)
        {
            ViewData["lst"] = dB.Products.ToList();
            return View();
        }

        public IActionResult Delete(int Id,[FromServices]DBDeiba dB)
        {
            Product product = dB.Find<Product>(Id);
             dB.Remove(product);
            dB.SaveChanges();
            return RedirectToAction("Lstproduct", "Panel");
        }

        public IActionResult Update(int Id,[FromServices]DBDeiba dB)
        {
            Product product = dB.Find<Product>(Id);

            ViewData["Barands"] = dB.Barands.ToList();
            ViewData["P"] = product;

            return View(product);
        }

        public IActionResult Updateconfirm(ProductViewModel model,[FromServices]DBDeiba dB)
        {
            var Product = dB.Find<Product>(model.Id);
            Product.Name = model.Name;
            Product.Mod = model.Mod;
            Product.Price = model.Price;
            Product.Title = model.Title;
            Product.Barandid = model.Barandid;
            if(model.Img != null)
            {
                byte[] b = new  byte[model.Img.Length];
                model.Img.OpenReadStream().Read(b, 0, b.Length);
                Product.Img = b;
            };
            dB.Update(Product);
            dB.SaveChanges();

            return RedirectToAction("Lstproduct", "Panel");
        }

      



    }
}
