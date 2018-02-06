using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.DAL
{
    public enum paymentType { cash, card, paypal }
    public class Bill
    {
        public Bill(List<Analysis> lAnalisys)
        {
            foreach (Analysis item in lAnalisys)
            {
                AmountBill += item.price;
            }
            idBill = Guid.NewGuid();
        }
        public Guid idBill{ get;}
        public DateTime dateBill { get; set; }
        public double AmountBill { get; } = 0;
        public paymentType payment { get; set; }
        public string descriptionBill { get; set; }
    }
}
