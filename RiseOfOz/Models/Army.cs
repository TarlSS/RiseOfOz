using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseOfOz.Models
{
    public class Army
    {
        public string Name { get; set; }
        public List<Troop> Troops { get; set; }
        public string[] Composition { get; set; }
        public int Size { get; set; }
    }
}
