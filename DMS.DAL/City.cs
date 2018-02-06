using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.DAL
{
    public class City
    {
        public City(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
        List<Laboratory> lLaboratories { get; set; } = new List<Laboratory>();
    }
}
