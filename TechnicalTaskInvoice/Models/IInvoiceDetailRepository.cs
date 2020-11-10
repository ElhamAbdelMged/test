using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechnicalTaskInvoice.Models
{
    public interface IInvoiceDetailRepository
    {
      
        IEnumerable<InvoiceDetail> GetByInvoiceHeaderID(int InvoiceHeaderID);
        IEnumerable<InvoiceDetail> GetAllInvoiceDetail();
        InvoiceDetail Add(InvoiceDetail InvoiceDetail);       
        InvoiceDetail Delete(int id);
    }
}
