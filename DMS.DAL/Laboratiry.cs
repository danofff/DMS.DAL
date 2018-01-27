using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.DAL
{
    [Serializable]
    public class Laboratiry
    {
        public int LabId { get; set; }
        public string LabNumber { get { return "lab#" + LabId; }}
        public string telNumber { get; set; }
        public City city { get; set; }
        public List<Analysis> lAnalisys { get; set; } = new List<Analysis>();
    }
}
