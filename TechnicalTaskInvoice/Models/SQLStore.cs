using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechnicalTaskInvoice.Models
{
    public class SQLStore : IStoreRepository
    {
        private readonly AppDbContext context;
        public SQLStore(AppDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<Store> GetAllStore()
        {
            return context.Store.ToList();
        }

        public Store GetStore(int ID)
        {
            return context.Store.Find(ID);
        }
    }
}
