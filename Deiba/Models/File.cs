using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Deiba.Models
{
    public class File
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Listmobile { get; set; }
        public byte[] Listlaptop { get; set; }

    }
}
