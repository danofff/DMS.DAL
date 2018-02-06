using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.DAL
{
    public enum sex { male, female };
    public class Patient:person
    {
        public Patient():this(0,"noname",sex.male)
        {
        }
        public Patient(int id,string name, sex g):base(id,name,g)
        {         
        }

        public List<AnalysisResult> AnalysisPassed { get; set; } = new List<AnalysisResult>();
    }
}
