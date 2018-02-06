﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.DAL
{
    public enum paymentType { cash, card, paypal }
    public class Bill
    {
        public Bill()
        {
            idBill = Guid.NewGuid();
        }
        public Guid idBill{ get;}
        public DateTime dateBill { get; set; }
        public double AmountBill { get; set; }
        public string currency { get; set; }
        public paymentType payment { get; set; }
        public string descriptionBill { get; set; }

    }
}
