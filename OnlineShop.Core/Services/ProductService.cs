using OnlineShop.Core.Interfaces;
using OnlineShop.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productrepository;

        public ProductService( IProductRepository productRepository)
        {
            _productrepository = productRepository;
        }
        public List<ProductAdminListViewModel> GetAllForAdmin()
        {
            var data = _productrepository.GetAll();
            return data.Select(p=>new ProductAdminListViewModel
            {
                Id= p.Id,
                CategoryName = String.Join(",", p.Categories.Select(c=>c.Name)) ,
                Name= p.Name,
                Price= p.Price,
            }).ToList();
        }
    }
}
