using System;
using System.Collections.Generic;

namespace Store.Shared
{
    public class  PaginationModel<T> where T: class
    {
        public int TotalItemsCount { get; set; }
        public List<T>  Items { get; set; }

        public PaginationModel()
        {
            Items = new List<T>();
        }
    }
}
