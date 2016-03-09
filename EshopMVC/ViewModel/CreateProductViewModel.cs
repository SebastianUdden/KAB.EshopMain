using EshopMVC.Models;
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
        public int Price { get; set; }

        //[Required(ErrorMessage = "Category is required")]
        [Range(1,int.MaxValue, ErrorMessage ="Välj en kategori")]
        public Category Category { get; set; }
        public string ProductDescription { get; set; }
        [Required(ErrorMessage = "Need to add amount of product(s)")]
        public int AmountToAdd { get; set; }

        public string ImageURL { get; set; }
    }
}
