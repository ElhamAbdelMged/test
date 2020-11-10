
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechnicalTaskInvoice.Models
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options)
          : base(options)
        {
        }

        public DbSet<Store> Store { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<Unit> Unit { get; set; }
        public DbSet<InvoiceHeader> InvoiceHeader { get; set; }
        public DbSet<InvoiceDetail> InvoiceDetail { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();
        }

    }
}
