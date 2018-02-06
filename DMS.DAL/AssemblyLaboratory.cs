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

        #region CREATE LABORATORY
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

        public string pathToLaborants { get
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
        

    }
}
