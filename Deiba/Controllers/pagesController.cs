using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Deiba.Data;
using Deiba.Models;
using Deiba.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Deiba.Controllers
{
    public class pagesController : Controller
    {
        public IActionResult Apple([FromServices] DBDeiba dB)
        {
            IQueryable<Product> product = dB.Products;
            ViewData["tst"] = product.Where(p => p.Barandid == 1).ToList();
            return View();

        }
        public IActionResult Asus([FromServices] DBDeiba dB)
        {
            IQueryable<Product> product = dB.Products;
            ViewData["tst"] = product.Where(p => p.Barandid == 2).ToList();
            return View();

        }
        public IActionResult HP([FromServices] DBDeiba dB)
        {
            IQueryable<Product> product = dB.Products;
            ViewData["tst"] = product.Where(p => p.Barandid == 3).ToList();
            return View();

        }
        public IActionResult Lenovo([FromServices] DBDeiba dB)
        {
            IQueryable<Product> product = dB.Products;
            ViewData["tst"] = product.Where(p => p.Barandid == 4).ToList();
            return View();

        }
        public IActionResult MicroSoft([FromServices] DBDeiba dB)
        {
            IQueryable<Product> product = dB.Products;
            ViewData["tst"] = product.Where(p => p.Barandid == 5).ToList();
            return View();

        }
        public IActionResult Samsung([FromServices] DBDeiba dB)
        {
            IQueryable<Product> product = dB.Products;
            ViewData["tst"] = product.Where(p => p.Barandid == 6).ToList();
            return View();

        }
        public IActionResult Dell([FromServices] DBDeiba dB)
        {
            IQueryable<Product> product = dB.Products;
            ViewData["tst"] = product.Where(p => p.Barandid == 7).ToList();
            return View();

        }
        public IActionResult MSI([FromServices] DBDeiba dB)
        {
            IQueryable<Product> product = dB.Products;
            ViewData["tst"] = product.Where(p => p.Barandid == 8).ToList();
            return View();

        }
        public IActionResult Desktop([FromServices] DBDeiba dB)
        {
            IQueryable<Product> product = dB.Products;
            ViewData["tst"] = product.Where(p => p.Barandid == 9).ToList();
            return View();

        } 
        public IActionResult Allinone([FromServices] DBDeiba dB)
        {
            IQueryable<Product> product = dB.Products;
            ViewData["tst"] = product.Where(p => p.Barandid == 10).ToList();
            return View();

        } 
        public IActionResult Janebi([FromServices] DBDeiba dB)
        {
            IQueryable<Product> product = dB.Products;
            ViewData["tst"] = product.Where(p => p.Barandid == 11).ToList();
            return View();

        }
    }
}
