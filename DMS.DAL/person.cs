using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.DAL
{
    [Serializable]
    public abstract class person
    {
        public person():this(0,"noname",sex.male)
        {

        }
        public person(int id, string name, sex g)
        {
            this.id = id;
            this.name = name;
            this.gender = g;
        }

        public int id { get; set; }
        public sex gender { get; set; }
        public string name { get; set; }

        public string phoneNumber { get; set; }

        private string iin;
        public string IIN
        {
            get { return iin; }
            set
            {
                if (IIN.Length != 12)
                {
                    Console.WriteLine("Wrong iin length");
                }
                else
                    iin = value;
            }
        }
        public DateTime DateofBirth { get; set; }
        public int Age { get { return (DateTime.Now.Year - DateofBirth.Year); } }
    }
}
