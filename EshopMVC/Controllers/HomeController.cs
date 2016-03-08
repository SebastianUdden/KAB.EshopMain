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
    public class HomeController : Controller
    {
        CustomerContext context;
        public HomeController(CustomerContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        // GET: /<controller>/
        [HttpPost]
        public IActionResult Create(CreateCustomerViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
                var dataManager = new DataManager(context);
                dataManager.AddCustomer(viewModel);
                return RedirectToAction(nameof(HomeController.Index));
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
