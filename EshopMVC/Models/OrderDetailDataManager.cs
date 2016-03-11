using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EshopMVC.Models
{
    public class OrderDetailDataManager
    {
        OrderDetailContext Context;

        public OrderDetailDataManager(OrderDetailContext context)
        {
            this.Context = context;
        }
        //public void CreateOrderDetail(OrderDetail det)
        //{
        //    Context.OrderDetails.Add(det);
        //    Context.SaveChanges();
        //}



    }
}
