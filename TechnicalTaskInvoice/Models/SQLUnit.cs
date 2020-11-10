using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechnicalTaskInvoice.Models
{
    public class SQLUnit : IUiteRepository
    {
        private readonly AppDbContext context;
        public SQLUnit(AppDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Unit> GetAllUite()
        
        {
           // var unit = context.Unit.ToList();
            return context.Unit.ToList();
        }

        public Unit GetUite(int ID)
        {
            return context.Unit.Find(ID);
        }
    }
}
