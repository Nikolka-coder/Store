using Store.DAL.Context;
using Store.DAL.Entities;
using Store.BAL.Interface;
using Store.DAL.Interface;
using Store.DAL.Repositories;
using Store.Shared;
using System.Collections.Generic;

namespace Store.BAL.Services
{
    public class StoreService : IStoreService
    {
        private readonly IStoreRepository _storeRepository;

        public StoreService(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }

        public PaginationModel<Product> GetAll(int pageNumber, int pageSize)
        {
            return _storeRepository.GetAll(pageNumber, pageSize);
        }
        public Product Create(Product entity)
        {
            return _storeRepository.Create(entity);
        }

        public IEnumerable<Category> GetCategories() => _storeRepository.GetCategories();
        
    }
}
