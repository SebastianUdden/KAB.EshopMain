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
        public List<Product> ShoppingCartList = new List<Product>();
        public ProductsController(ProductContext context)
        {
            this.Context = context;
        }
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
            var model = productDataManager.AddProductToShoppingCart(id);
            ShoppingCartList.Add(model);
            return View(ShoppingCartList);
        }
    }
}
