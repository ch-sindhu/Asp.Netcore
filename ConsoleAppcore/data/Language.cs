using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleAppcore.data
{
    public class Language
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Books> Books { get; set; }

    }
}
