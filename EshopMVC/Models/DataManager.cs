using EshopMVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EshopMVC.Models
{
    public class DataManager
    {
        CustomerContext context;

        public DataManager(CustomerContext context)
        {
            this.context = context;
        }

        public void AddCustomer(CreateCustomerViewModel viewModel)
        {
            Customer c = new Customer();
            c.FirstName = viewModel.FirstName;
            c.LastName = viewModel.LastName;
            c.Email = viewModel.Email;
            c.Password = viewModel.Password;
            c.Adress = viewModel.Adress;
            c.Ssn = viewModel.Ssn;

            context.Customers.Add(c);
            context.SaveChanges();
        }

    }
}
