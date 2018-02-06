using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Configuration;
using System.Collections.Specialized;

namespace DMS.DAL
{
    public delegate void sendMessage(string message);
    public class AssemblyLaboratory
    {
        sendMessage sm;
        public void RegisterDelegate(sendMessage d)
        {
            sm = d;
        }

        #region LABORATORY HANDLER
        public void CreateLaboratory(Laboratory l)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(Laboratory));
            using (FileStream fs=new FileStream("lab_" + l.LabId + ".xml", FileMode.OpenOrCreate))
            {
                try
                {
                    formatter.Serialize(fs, l);
                    if(sm!=null)
                        sm.Invoke("Лаборатория успешно добавлена");
                }
                catch (Exception ex)
                {
                    if(sm!=null)
                        sm.Invoke(ex.Message);
                }
            }
        }
        #endregion

        #region LABORANTS HANDLER
        public string pathToLaborants {
            get
            {
                var url = ConfigurationManager.GetSection("Path") as NameValueCollection;
                return url["pathtoLaborants"];
            }
            }
        public List<Laborant> getLaborants()
        {
            List<Laborant> listLaborants = null;
            XmlSerializer formatter = new XmlSerializer(typeof(Laborant[]));
            using (FileStream fs = new FileStream(pathToLaborants, FileMode.OpenOrCreate))
            {
                try
                {
                    listLaborants = ((Laborant[])formatter.Deserialize(fs)).ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }    
            }
            return listLaborants;
        }

        public void createLaborant(Laborant l)
        {
            List<Laborant> listLaborants = getLaborants();
            if (listLaborants==null)
            {
                listLaborants = new List<Laborant>();
            }
            listLaborants.Add(l);
            XmlSerializer formatter = new XmlSerializer(typeof(Laborant[]));
            using (FileStream fs = new FileStream(pathToLaborants, FileMode.OpenOrCreate))
            {
                try
                {
                    formatter.Serialize(fs,listLaborants.ToArray());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public Laborant LogIn(string login, string password)
        {
            Laborant l = null;
            List<Laborant> listLaborant = getLaborants();
            if (listLaborant != null)
            {
              l = listLaborant.FirstOrDefault(w => w.login == login && w.password == password);
            }
            return l;
        }
        #endregion

        #region ANALISYS HANDLER
        public string pathToAnalisys
        {
            get
            {
                var url = ConfigurationManager.GetSection("Path") as NameValueCollection;
                return url["pathtoAnalisys"];
            }
        }
        public List<Analysis> getAnalisys()
        {
            List<Analysis> listAnalisys = null;
            XmlSerializer formatter = new XmlSerializer(typeof(Analysis[]));
            using (FileStream fs = new FileStream(pathToAnalisys, FileMode.OpenOrCreate))
            {
                try
                {
                    listAnalisys = ((Analysis[])formatter.Deserialize(fs)).ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return listAnalisys;
        }

        public void createAnalisys(Analysis an)
        {
            List<Analysis> listAnalisys = getAnalisys();
            if (listAnalisys == null)
            {
                listAnalisys = new List<Analysis>();
            }
            listAnalisys.Add(an);
            XmlSerializer formatter = new XmlSerializer(typeof(Analysis[]));
            using (FileStream fs = new FileStream(pathToLaborants, FileMode.OpenOrCreate))
            {
                try
                {
                    formatter.Serialize(fs, listAnalisys.ToArray());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        #endregion

        #region ANALISYS RESULT HANDLER
        public string pathToAnalisysResults
        {
            get
            {
                var url = ConfigurationManager.GetSection("Path") as NameValueCollection;
                return url["pathtoAnalisysResult"];
            }
        }
        public List<AnalysisResult> getAnalisysResult()
        {
            List<AnalysisResult> listAnalisysResult = null;
            XmlSerializer formatter = new XmlSerializer(typeof(AnalysisResult[]));
            using (FileStream fs = new FileStream(pathToAnalisys, FileMode.OpenOrCreate))
            {
                try
                {
                    listAnalisysResult = ((AnalysisResult[])formatter.Deserialize(fs)).ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return listAnalisysResult;
        }

        public void createAnalisysResult(AnalysisResult an)
        {
            List<AnalysisResult> listAnalisysResult = getAnalisysResult();
            if (listAnalisysResult == null)
            {
                listAnalisysResult = new List<AnalysisResult>();
            }
            listAnalisysResult.Add(an);
            XmlSerializer formatter = new XmlSerializer(typeof(AnalysisResult[]));
            using (FileStream fs = new FileStream(pathToLaborants, FileMode.OpenOrCreate))
            {
                try
                {
                    formatter.Serialize(fs, listAnalisysResult.ToArray());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        #endregion

        #region BILLS HANDLER
        public string pathToBills
        {
            get
            {
                var url = ConfigurationManager.GetSection("Path") as NameValueCollection;
                return url["pathToBills"];
            }
        }
        public List<Bill> getBills()
        {
            List<Bill> listBills = null;
            XmlSerializer formatter = new XmlSerializer(typeof(Bill[]));
            using (FileStream fs = new FileStream(pathToAnalisys, FileMode.OpenOrCreate))
            {
                try
                {
                    listBills = ((Bill[])formatter.Deserialize(fs)).ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return listBills;
        }

        public void createAnalisysResult(Bill b)
        {
            List<Bill> listBills = getBills();
            if (listBills == null)
            {
                listBills = new List<Bill>();
            }
            listBills.Add(b);
            XmlSerializer formatter = new XmlSerializer(typeof(Bill[]));
            using (FileStream fs = new FileStream(pathToLaborants, FileMode.OpenOrCreate))
            {
                try
                {
                    formatter.Serialize(fs, listBills.ToArray());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        #endregion

    }
}
