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



    }
}
