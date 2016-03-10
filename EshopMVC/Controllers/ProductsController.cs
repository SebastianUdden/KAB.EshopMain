using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using EshopMVC.Models;
using EshopMVC.ViewModel;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace EshopMVC.Controllers
{
    public class ProductsController : Controller
    {
        ProductContext Context;
        //OrdersContext Context2;
        //OrderDetailContext Context3;

        public ProductsController(ProductContext context)
        {
            this.Context = context;
        }

        //public ProductsController(ProductContext context, OrdersContext context2, OrderDetailContext context3)
        //{
        //    this.Context = context;
        //    this.Context2 = context2;
        //    this.Context3 = context3;
        //}
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateProduct(CreateProductViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var productDataManager = new ProductDataManager(Context);
            productDataManager.AddProduct(viewModel);

            return RedirectToAction(nameof(ProductsController.Index));
        }

        //[HttpPost]
        public IActionResult ProductCategory(int id)
        {
            var productDataManager = new ProductDataManager(Context);
            var model = productDataManager.GetProductByCategory(id);
            return View(model);
        }

        public IActionResult Product(int id)
        {
            var productDataManager = new ProductDataManager(Context);
            var model = productDataManager.GetProductById(id);
            return View(model);
        }
        public IActionResult ShoppingCart(int id)
        {
            var productDataManager = new ProductDataManager(Context);
            productDataManager.AddProductToShoppingCart(id);
            var a = productDataManager.ShoppingCart();
            if(a.Count > 0)
            {
            return View(a);
            }
            return View();
        }
        
        //public IActionResult CheckoutComplete()
        //{
        //    var productDataManager = new ProductDataManager(Context/*, Context2, Context3*/);
        //    productDataManager.RegisterCheckout();
        //    return View();
        //}
    }
}
