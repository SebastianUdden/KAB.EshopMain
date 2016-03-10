using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EshopMVC.Models
{
    public class ShoppingCartDataManager
    {
        ShoppingCartContext Context;

        public ShoppingCartDataManager(ShoppingCartContext context)
        {
            this.Context = context;
        }


        public void SaveOrder(List<ShoppingCartItem> cartItems)
        {
            foreach (var item in cartItems)
            {
                ShoppingCartItem p = new ShoppingCartItem();
                p.ProductName = item.ProductName;
                p.Price = item.Price;

                Context.Orders.Add(p);
                Context.OrderDetails.Add(p);

                Context.SaveChanges();
            }
        }
    }
}
