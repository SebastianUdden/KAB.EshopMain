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
    public class ManageAccountController : Controller
    {
        //ManageAccountContext context;

        //public ManageAccountController


        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
    }
}
