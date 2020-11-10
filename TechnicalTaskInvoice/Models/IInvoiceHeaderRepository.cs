using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechnicalTaskInvoice.Models
{
    public interface IInvoiceHeaderRepository
    {
        InvoiceHeader GetInvoiceHeader(int ID);
        IEnumerable<InvoiceHeader> GetAllInvoiceHeader();
        InvoiceHeader Add(InvoiceHeader InvoiceHeader);
        InvoiceHeader Delete(int id);
    }
}
