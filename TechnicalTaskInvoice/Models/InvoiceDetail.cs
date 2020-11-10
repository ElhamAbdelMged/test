using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechnicalTaskInvoice.Models
{
    public class InvoiceDetail
    {
        public int ID { get; set; }
        public int InvoiceHeaderID { get; set; }
        public int ItemID { get; set; }
        public int UnitID { get; set; }
        public double Price { get; set; }
        public int quntity { get; set; }
        public double Total { get; set; }
        public double Discount { get; set; }
        public double Net { get; set; }


    }
}
