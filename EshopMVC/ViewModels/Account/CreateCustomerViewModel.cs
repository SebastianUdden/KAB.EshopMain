using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EshopMVC.ViewModel
{
    public class CreateCustomerViewModel
    {
        [Display(Name = "First name")]
        [Required(ErrorMessage ="First name is required")]
        public string FirstName { get; set; }

        [Display(Name = "Last name")]
        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "E-mail is required")]
        [EmailAddress(ErrorMessage ="E-mail format is invalid")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        //[StringLength(255, MinimumLength = 8)]
        //[MembershipPassword()]
        //Hittade inte using System.Web.Security, vill fatta så jag frågar Patrik/Pontus sen
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Required(ErrorMessage ="Please re-enter password")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string ComparePassword{ get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Address is required")]
        public string Adress { get; set; }

        [Display(Name = "Social Security Number")]
        [Required(ErrorMessage ="Ssn is required")]
        public string Ssn { get; set; }
        
        //[Range(typeof(bool), "true", "true", ErrorMessage = "Du måste gå med på våra sjuka villkor")]
        //public bool AcceptTerms { get; set; }

    }
}
