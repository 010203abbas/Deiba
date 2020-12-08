using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Deiba.ViewModels
{
    public class FileViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IFormFile Listmobile { get; set; }
        public IFormFile Listlaptop { get; set; }
    }
}
