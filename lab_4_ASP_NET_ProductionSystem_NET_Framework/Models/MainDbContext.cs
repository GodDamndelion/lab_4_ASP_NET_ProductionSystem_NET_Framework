using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace lab_4_ASP_NET_ProductionSystem_NET_Framework.Models
{
    public class MainDbContext : DbContext
    {
        public DbSet<Type_of_product> Types_of_products { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Use_in> Used_in { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Production_machine> Production_machines { get; set; }
    }
}