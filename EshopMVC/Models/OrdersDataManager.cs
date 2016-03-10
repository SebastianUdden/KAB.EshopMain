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
        public void CreateOrder()
        {
            DateTime dateTime = DateTime.Now;
            var o = new Order();
            o.Date = dateTime;
            Context.Orders.Add(o);
        }
    }
}
