using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Deiba.Data;
using Deiba.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using PagedList;


namespace Deiba.Controllers
{
    public class HomeController : Controller
    {
        

        public IActionResult Index([FromServices]DBDeiba dB,int Pageid=1)
        {
            int skip = (Pageid - 1) * 3;
            ViewData["tst"] = dB.Products.OrderBy(p=>p.Id).Skip(skip).Take(3).ToList();
            int Count = dB.Products.Count();
            ViewBag.PageId = Pageid;
            ViewBag.Pagecount = Count / 3;
            
            return View();
        }
       
      
       

    }
}
