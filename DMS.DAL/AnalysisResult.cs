using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.DAL
{
    public class AnalysisResult
    {

        public AnalysisResult(Analysis an, Patient pat, Laborant lab,string res)
        {
            Analis = an;
            Pat = pat;
            Labt = lab;
            result = res;
            //кодируем ИД результата
            Random rnd = new Random();
            resID = "" + rnd.Next(1000, 10000) + an.name.ToArray()[0] + pat.IIN.ToArray()[0]+lab.id.ToString().ToArray()[0];
        }
        public string resID { get;}
        public Analysis Analis { get; set; }
        public Patient Pat { get; set; }
        public Laborant Labt { get; set; }
        public string result { get; set; }

    }
}
