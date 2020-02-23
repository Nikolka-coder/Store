using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Store.DAL.Entities
{
   
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public ICollection<Product> Products { get; set; }
        public Category()
        {
            Products = new List<Product>();
        }
    }
}
