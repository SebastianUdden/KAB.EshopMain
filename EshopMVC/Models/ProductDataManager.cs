using EshopMVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EshopMVC.Models
{
    public class ProductDataManager
    {
        ProductContext Context;
        //OrdersContext Context2;
        //OrderDetailContext Context3;
        static List<Product> ShoppingCartList = new List<Product>();

        public ProductDataManager(ProductContext context)
        {
            this.Context = context;
        }

        //public ProductDataManager(ProductContext context, OrdersContext context2, OrderDetailContext context3)
        //{
        //    this.Context = context;
        //    this.Context2 = context2;
        //    this.Context3 = context3;
        //}
        public void AddProduct(CreateProductViewModel viewModel)
        {
            Product p = new Product();
            p.ProductName = viewModel.ProductName;
            p.Price = viewModel.Price;
            p.PictureLink = viewModel.ImageURL;
            p.ProductDescription = viewModel.ProductDescription;
            p.Stock = viewModel.AmountToAdd;
            p.CategoryId = viewModel.Category;

            Context.Products.Add(p);

            Context.SaveChanges();
        }

        public Product GetProductById(int id)
        {
            //this needs testing, *should* return a product object from the database
            var Product = Context.Products.Select(x => new Product
            {
                Id = x.Id,
                ProductName = x.ProductName,
                ProductDescription = x.ProductDescription,
                Price = x.Price,
                PictureLink = x.PictureLink,
                Stock = x.Stock,
                CategoryId = x.CategoryId,
            }).Where(x => x.Id == id).ToArray();
            return Product[0];
        }

        // När man kör debugger får vi exception på Product[0]. F11 tre gånger så kör den. 
        // När man kör sidan vanligt fungerar allt.

        public ProductListViewModel[] GetProductByCategory(int categoryId)
        {
            //untested
            var Product = Context.Products.Select(x => new ProductListViewModel
            {
                Id = x.Id,
                ProductName = x.ProductName,
                ProductDescription = x.ProductDescription,
                Price = x.Price,
                ImageURL = x.PictureLink,
                Stock = x.Stock,
                CategoryId = x.CategoryId
            }).Where(x => x.CategoryId == categoryId).ToArray();
            return Product;
        }



        public void AddProductToShoppingCart(int id)
        {
            if (Context.Products.Count(x => x.Id == id) > 0)
            {
                var Product = Context.Products.Select(x => new Product
                {
                    Id = x.Id,
                    ProductName = x.ProductName,
                    ProductDescription = x.ProductDescription,
                    Price = x.Price,
                    PictureLink = x.PictureLink,
                    Stock = x.Stock,
                    CategoryId = x.CategoryId
                }).Where(x => x.Id == id).First();
                ShoppingCartList.Add(Product);
            }
        }

        public List<ProductListViewModel> ShoppingCart()
        {
            if (ShoppingCartList.Count == 0)
                return new List<ProductListViewModel>();

            var ProductList = ShoppingCartList.Select(x => new ProductListViewModel
            {
                Id = x.Id,
                ProductName = x.ProductName,
                ProductDescription = x.ProductDescription,
                Price = x.Price,
                ImageURL = x.PictureLink,
                Stock = x.Stock,
                CategoryId = x.CategoryId
            }).ToList();
            return ProductList;
        }
        public void RegisterCheckout(int id)
        {
            ///ENDAST FÖR TESTNING
            ///
            id = 6;
            if (id > 0)
            {
                var orderId = CreateOrder(id);
                foreach (var item in ShoppingCartList.GroupBy(x=>x.Id))
                {

                    var p = new OrderDetail();
                    p.ProductId = item.First().Id;
                    p.Quantity = item.Count();
                    p.CurrentPrice = item.First().Price;
                    p.OrderId = orderId;

                    Context.OrderDetails.Add(p);
                    Context.SaveChanges();
                }
                ShoppingCartList.Clear();
            }
        }
        public int CreateOrder(int id)
        {
            DateTime dateTime = DateTime.Now;
            var o = new Order();
            o.CustomerId = id;
            Context.Orders.Add(o);
            Context.SaveChanges();

            return Context.Orders.Last().Id;
        }

        //public List<OrderHistory> GetOrderHistory(int id)
        //{
            
        //}
    }
}
