using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Deiba.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Mod { get; set; }
        public string Price { get; set; }
        public string Title { get; set; }
        public IFormFile Img { get; set; }
        public int Barandid { get; set; }


    }
   
}
