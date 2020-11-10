using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechnicalTaskInvoice.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Unit>().HasData(
           new Unit
           {
               ID = 1,
               Name = "Pound",
         
           },
              new Unit
              {
                  ID = 2,
                  Name = "Dollar",
             
              }

           );


      modelBuilder.Entity<Store>().HasData(
      new Store
      {
          ID = 1,
          Name = "MainStore",

      },
         new Unit
         {
             ID = 2,
             Name = "SubStore",

         }
         ,
         new Unit
         {
             ID = 3,
             Name = "NewStore",

         }

      );


   modelBuilder.Entity<Item>().HasData(
      new Item
      {
          ID = 1,
          Name = "T_shirt",

      },
         new Item
         {
             ID = 2,
             Name = "sweater",

         }
         ,
         new Item
         {
             ID = 3,
             Name = "jacket",

         }
         ,
         new Item
         {
             ID = 4,
             Name = "coat",

         }
         ,
         new Item
         {
             ID = 5,
             Name = "jeans",

         }
         ,
         new Item
         {
             ID = 6,
             Name = "tracksuit",

         }
         ,
         new Item
         {
             ID = 7,
             Name = "shorts",

         }
         ,
         new Item
         {
             ID = 8,
             Name = "vest"
         }
             ,
             new Item
             {
                 ID = 9,
                 Name = "pyjamas",

             },
             new Item
             {
                 ID = 10,
                 Name = "shoes",

             },
             new Item
             {
                 ID = 11,
                 Name = "dress",

             },
             new Item
             {
                 ID = 12,
                 Name = "heels",

             }
             , new Item
             {
                 ID = 13,
                 Name = "skirt",

             },
             new Item
             {
                 ID = 14,
                 Name = "panties",

             },
              new Item
              {
                  ID = 15,
                  Name = "blouse",

              }
        

      );


        }


    }
}
