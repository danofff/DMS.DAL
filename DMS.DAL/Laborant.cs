using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.DAL
{
    [Serializable]
    public class Laborant:person
    {
        public string login { get; set; }
        public string password { get; set; }

        public Laboratiry workPlace { get; set; }
    }
}
