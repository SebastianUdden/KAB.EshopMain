﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using EshopMVC.Models;
using EshopMVC.ViewModel;

using Microsoft.AspNet.Http.Authentication;
using System.Security.Claims;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace EshopMVC.Controllers
{
    public class CustomersController : Controller
    {
        CustomerContext context;
        public CustomersController(CustomerContext context)
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
                //var x = dataManager.GetCustomer(1);
                return RedirectToAction(nameof(CustomersController.Index));
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginCustomerViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            
            var dataManager = new DataManager(context);
            HttpContext.Authentication.SignOutAsync("Cookies");
            var a = dataManager.GetCustomer(viewModel.Email, viewModel.Password);
            if(a != null && a.Length>0)
            {
            var s = new Claim("FirstName",a.First().FirstName);
            var newId = new ClaimsIdentity("application", "name", "role");
            newId.AddClaim(new Claim("FirstName", a.First().FirstName));
            newId.AddClaim(new Claim("Email", a.First().Email));
            HttpContext.Authentication.SignInAsync("Cookies", new ClaimsPrincipal(newId));
            Response.Cookies.Append("Email", a.First().Email);
            Response.Cookies.Append("FirstName", a.First().FirstName);
                return RedirectToAction(nameof(CustomersController.Create));
            }
            //var x = dataManager.GetCustomer(1);
            //return RedirectToAction(nameof(CustomersController.Index));
            return View(viewModel);
            //return RedirectToAction(Index());
        }
        public IActionResult Index()
        {
            return View();
        }

    }
}
