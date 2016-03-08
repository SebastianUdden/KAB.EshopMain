using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EshopMVC.ViewModel
{
    public class CreateCustomerViewModel
    {
        [Required(ErrorMessage ="Name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage ="Email format is invalid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Adress { get; set; }

        [Required(ErrorMessage ="Name is required")]
        public string Ssn { get; set; }

    }
}
