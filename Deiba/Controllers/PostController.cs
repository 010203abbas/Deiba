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
    public class PostController : Controller
    {
        public IActionResult Postinsert([FromServices] DBDeiba dB)
        {
            Post post = new Post();
            ViewData["P"] = dB.Posts.ToList(); 
            return View();
        }
        public IActionResult Postconfirm(PostViewModel model,[FromServices]DBDeiba dB)
        {
            Post post = new Post { 
            Name =model.Name,
            Title =model.Title
            
            };
            dB.Add(post);
            dB.SaveChanges();

            return RedirectToAction("Postinsert","Post");
        }
    }
}
