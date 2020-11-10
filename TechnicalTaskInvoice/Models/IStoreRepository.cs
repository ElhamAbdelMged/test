using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechnicalTaskInvoice.Models
{
    public interface IStoreRepository
    {
        Store GetStore(int ID);
        IEnumerable<Store> GetAllStore();
    }
}
