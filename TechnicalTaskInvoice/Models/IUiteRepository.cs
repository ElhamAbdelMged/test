using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechnicalTaskInvoice.Models
{
    public interface IUiteRepository
    {
        Unit GetUite(int ID);
        IEnumerable<Unit> GetAllUite();

    }
}
