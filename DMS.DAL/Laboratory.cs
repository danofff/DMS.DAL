using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.DAL
{
    [Serializable]
    public class Laboratory
    {
        public string LabId { get; set; } 
        public string LabNumber { get { return "lab#" + LabId; }}
        public string telNumber { get; set; }
        public City city { get; set; }
        public List<Analysis> lAnalisys { get; set; } = new List<Analysis>();
        public List<Laborant> lLaborants { get; set; } = new List<Laborant>();
        public List<AnalysisResult> lResult { get; set; } = new List<AnalysisResult>();
        public List<Bill> lBill { get; set; } = new List<Bill>();        
    }
}
