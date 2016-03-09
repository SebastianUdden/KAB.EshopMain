using EshopMVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EshopMVC.Models
{
    public class DataManager
    {
        CustomerContext Context;

        public DataManager(CustomerContext context)
        {
            this.Context = context;
        }

        //customer related methods
        public void AddCustomer(CreateCustomerViewModel viewModel)
        {
            Customer c = new Customer();
            c.FirstName = viewModel.FirstName;
            c.LastName = viewModel.LastName;
            c.Email = viewModel.Email;
            c.Password = viewModel.Password;
            c.Adress = viewModel.Adress;
            c.Ssn = viewModel.Ssn;

            Context.Customers.Add(c);
            Context.SaveChanges();
        }

        public Customer GetCustomer(int id)
        {
            //this needs testing, *should* return a customer object from the database
            var Customer = Context.Customers.Select(x => new Customer
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                Password = x.Password,
                Adress = x.Adress,
                Ssn = x.Ssn
            }).ToArray()/*.Where(x => x.Id == id)*/;
            return Customer[0];
        }
    }
}
