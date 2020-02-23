using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MyStore.UI.ViewModels;
using Store.DAL.Entities;
using Store.BAL.Interface;
using Store.Shared;

namespace MyStore.UI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IStoreService _storeService;
        public HomeController(IStoreService storeService)
        {
            _storeService = storeService;
        }
        [HttpGet("GetCategories")]
        public IEnumerable<Category> GetCategories() => _storeService.GetCategories();

        [HttpGet("GetAll")]
        public PaginationModel<ProductViewModel> GetAll(int pageNumber, int pageSize)
        {
           var result = _storeService.GetAll(pageNumber, pageSize);
            PaginationModel<ProductViewModel> products = new PaginationModel<ProductViewModel>
            {
                TotalItemsCount = result.TotalItemsCount
            };
            foreach (var i in result.Items)
            {
                products.Items.Add(new ProductViewModel { 
                    Id = i.ProductId,
                    Name = i.ProductName,
                    CategoryName = i.Category.CategoryName
                });
            }
            return products;
        }
        [HttpPost("Create")]
        public void Create(Product entity)
        {
            _storeService.Create(entity);
        }
    }
}
