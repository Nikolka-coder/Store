using Store.DAL.Entities;
using Store.Shared;
using System.Collections.Generic;

namespace Store.BAL.Interface
{
    public interface IStoreService
    {
        PaginationModel<Product> GetAll(int pageNumber, int pageSize);
        Product Create(Product entity);
        public IEnumerable<Category> GetCategories();
    }
}
