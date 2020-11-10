using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechnicalTaskInvoice.Models
{
    public class InvoiceHeader
    {
        public InvoiceHeader()
        {
            InvoiceDetails = new HashSet<InvoiceDetail>();
        }
        public int ID { get; set; }
        public string Invoice_NO { get; set; }
        public int StoreID { get; set; }
        public DateTime IvoiceDate { get; set; }
        public double Total { get; set; }
        public double Taxes { get; set; }
        public double Net { get; set; }

        public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; }

    }
}
