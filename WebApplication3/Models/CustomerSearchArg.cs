using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class CustomerSearchArg
    {
        public string CustomerID{ get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string delbtn { get; set; }
        public string editbtn { get; set; }

    }
}