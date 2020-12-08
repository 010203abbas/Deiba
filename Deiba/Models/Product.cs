using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace Deiba.Models
{
    public class Product
    {
        public int Id { get; set; }
       
        public string Name { get; set; }
        public string Mod { get; set; }
        public string Price { get; set; } 
        public string Title { get; set; }
        public byte[] Img { get; set; }

       
        public int Barandid { get; set; }
        [Foreignkey("Barandid")]

        public Barand Barand { get; set; }
    }
   

   
}
