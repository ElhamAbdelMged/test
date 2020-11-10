using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechnicalTaskInvoice.Models
{
    public interface IItemRepository
    {
        Item GetItem(int ID);
        IEnumerable<Item> GetAllItem();

    }
}
