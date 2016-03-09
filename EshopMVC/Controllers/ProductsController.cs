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
        ProductContext context;
        public ProductsController(ProductContext context)
        {
            this.context = context;
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

            var productDataManager = new ProductDataManager(context);
            productDataManager.AddProduct(viewModel);

            return RedirectToAction(nameof(HomeController.Index));
        }
    }
}
