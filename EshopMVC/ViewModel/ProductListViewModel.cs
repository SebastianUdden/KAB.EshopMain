using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EshopMVC.ViewModel
{
    public class ProductListViewModel
    {
        public int Category { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public string ProductDescription { get; set; }
        public string ImageURL { get; set; }
    }
}
