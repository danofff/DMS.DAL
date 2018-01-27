using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DMS.DAL;
using GeneratorName;
using static System.Console;

namespace DMS
{
    class Program
    {
        static void Main(string[] args)
        {
            AssemblyLaboratory al = new AssemblyLaboratory();
            Laborant l = new Laborant { name = "SomeName", DateofBirth = DateTime.Now.AddMonths(-400), gender = sex.female, login = "master", password = "noneedpassword" };
            al.createLaborant(l);


            /*sendMessage sm;
            sm = sendMessage;
            AssemblyLaboratory al = new AssemblyLaboratory();
            al.RegisterDelegate(sm);
            /*Laboratiry lab = new Laboratiry { adress = "someadres", LabId = 1, LabNumber = "ln#1",telNumber="8-701-000-00-01" };*/
            //al.CreateLaboratory(lab);*/
        }
        static void sendMessage(string mes)
        {
            Console.WriteLine(mes);
        }
    }
}
