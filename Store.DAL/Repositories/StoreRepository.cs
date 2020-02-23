using Microsoft.EntityFrameworkCore;
using Store.DAL.Context;
using Store.DAL.Entities;
using Store.DAL.Interface;
using Store.Shared;
using System.Collections.Generic;
using System.Linq;

namespace Store.DAL.Repositories
{
    public class StoreRepository : IStoreRepository
    {
        private readonly StoreContext _storeContext;
        public StoreRepository(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }
        
        public PaginationModel<Product> GetAll(int pageNumber, int pageSize) 
        {
            _storeContext.SaveChanges();
            PaginationModel<Product> items = new PaginationModel<Product>
            {
                Items = _storeContext.Products.Skip((pageNumber - 1) * pageSize).Take(pageSize).Include(x => x.Category).ToList(),
                TotalItemsCount = _storeContext.Products.Count()
            };
            
            return items;
        } 

        public Product Create(Product entity)
        {
            Category category = _storeContext.Categories.Where(x => x.CategoryID == entity.CategoryID).FirstOrDefault();
            entity.Category = category;
            _storeContext.Add(entity);
            _storeContext.SaveChanges();
            return entity;
        }

        public IEnumerable<Category> GetCategories() => _storeContext.Categories.ToList();
    }
}
