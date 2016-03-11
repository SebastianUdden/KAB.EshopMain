using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EshopMVC.Models
{
    public class OrdersDataManager
    {
        OrdersContext Context;

        public OrdersDataManager(OrdersContext context)
        {
            this.Context = context;
        }
        //public int CreateOrder()
        //{
        //    DateTime dateTime = DateTime.Now;
        //    var o = new Order();
        //    Context.Orders.Add(o);
        //    Context.SaveChanges();

        //    return Context.Orders.Last().Id;
        //}
    }
}
