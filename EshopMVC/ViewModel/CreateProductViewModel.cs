using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EshopMVC.ViewModel
{
    public class CreateProductViewModel
    {
        [Required(ErrorMessage = "Product ID is required")]
        public string ProductID { get; set; }

        [Required(ErrorMessage = "Product name is required")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Product price must be set")]
        public string Price { get; set; }

        [Required(ErrorMessage = "Category is required")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Need to add amount of product(s)")]
        public string AmountToAdd { get; set; }

        [Required(ErrorMessage = "URL is required")]
        public string ImageURL { get; set; }
    }
}
