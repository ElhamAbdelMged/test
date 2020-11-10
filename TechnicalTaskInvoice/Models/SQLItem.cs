using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechnicalTaskInvoice.Models
{
    public class SQLItem : IItemRepository
    {
        private readonly AppDbContext context;
        public SQLItem(AppDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<Item> GetAllItem()
        {
            return context.Item.ToList();
        }

        public Item GetItem(int ID)
        {
            return context.Item.Find(ID);
        }
    }
}
