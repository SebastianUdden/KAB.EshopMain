using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EshopMVC.Models
{
    public class Admin
    {
        [Key]
        public int UserId { get; set; }
    }
}
