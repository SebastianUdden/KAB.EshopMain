using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EshopMVC.Models
{
    public class Order
    {
        public string Comment { get; set; }
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int CustomerId { get; set; }
    }
}
