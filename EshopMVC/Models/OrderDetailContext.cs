//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.Data.Entity;

//namespace EshopMVC.Models
//{
//    public class OrderDetailContext : DbContext
//    {
//        public DbSet<OrderDetail> OrderDetails { get; set; }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            modelBuilder.Entity<OrderDetail>().ToTable("OrderDetail");
//        }
//    }
//}
