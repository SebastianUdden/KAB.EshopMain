using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EshopMVC.Models
{
    public class ShoppingCartContext : DbContext
    {
        public DbSet<ShoppingCartItem> Orders { get; set; }
        public DbSet<ShoppingCartItem> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShoppingCartItem>().ToTable("Orders");
            modelBuilder.Entity<ShoppingCartItem>().ToTable("OrderDetails");
        }
    }

    public class ShoppingCartItem
    {
        public string ProductName { get; set; }
        public int Price { get; set; }
        public int Id { get; set; }
    }
}
