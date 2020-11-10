using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechnicalTaskInvoice.Models
{
    public class SQLInvoiceHeader:IInvoiceHeaderRepository
    {
        private readonly AppDbContext context;
        public SQLInvoiceHeader(AppDbContext context)
        {
            this.context = context;
        }

        public InvoiceHeader Add(InvoiceHeader InvoiceHeader)
        {
            context.InvoiceHeader.Add(InvoiceHeader);
            context.SaveChanges();
            return InvoiceHeader;
        }

        public InvoiceHeader Delete(int id)
        {
            InvoiceHeader invoiceHeader = context.InvoiceHeader.Find(id);
            if (invoiceHeader != null)
            {
                context.InvoiceHeader.Remove(invoiceHeader);
                context.SaveChanges();
            }
            return invoiceHeader;
        }

        public IEnumerable<InvoiceHeader> GetAllInvoiceHeader()
        {
            return context.InvoiceHeader.ToList();
        }

        public InvoiceHeader GetInvoiceHeader(int ID)
        {
            return context.InvoiceHeader.Find(ID);
         }

     
    }
}
