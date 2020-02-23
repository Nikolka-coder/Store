using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Store.DAL.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
       
        public int CategoryID { get; set; }
        public Category Category { get; set; }
        public Product()
        {
           Category = new Category();
        }
    }
   
}
