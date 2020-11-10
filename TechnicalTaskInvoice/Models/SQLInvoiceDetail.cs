using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechnicalTaskInvoice.Models
{
    public class SQLInvoiceDetail:IInvoiceDetailRepository
    {
        private readonly AppDbContext context;
        public SQLInvoiceDetail(AppDbContext context)
        {
            this.context = context;
        }

        public InvoiceDetail Add(InvoiceDetail InvoiceDetail)
        {
            context.InvoiceDetail.Add(InvoiceDetail);
            context.SaveChanges();
            return InvoiceDetail;

        }

        public InvoiceDetail Delete(int id)
        {
            InvoiceDetail invoiceDetail = context.InvoiceDetail.Find(id);
            if (invoiceDetail != null)
            {
                context.InvoiceDetail.Remove(invoiceDetail);
                context.SaveChanges();
            }
            return invoiceDetail;
        }

     

        public IEnumerable<InvoiceDetail> GetAllInvoiceDetail()
        {
            return context.InvoiceDetail.ToList();
        }

        public IEnumerable<InvoiceDetail> GetByInvoiceHeaderID(int InvoiceHeaderID)
        {
            var InvoiceDetailList = context.InvoiceDetail.Where(ww=>ww.InvoiceHeaderID == InvoiceHeaderID).ToList();
            return InvoiceDetailList;
        }

        public InvoiceDetail GetEmployee(int ID)
        {
            return context.InvoiceDetail.Find(ID);
        }

       
    }
}
