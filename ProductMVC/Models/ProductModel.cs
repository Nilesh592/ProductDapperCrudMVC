using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductMVC.Models
{
    public class ProductModel
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
    }
}