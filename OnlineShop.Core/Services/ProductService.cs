using OnlineShop.Core.Interfaces;
using OnlineShop.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.Core.Entities;
using OnlineShop.Core.ViewModels.Products;

namespace OnlineShop.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productrepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _uow;

        public ProductService( 
            IProductRepository productRepository,
            ICategoryRepository categoryRepository,
            IUnitOfWork uow
            )
        {
            _productrepository = productRepository;
            _categoryRepository = categoryRepository;
            _uow = uow;
        }

        public void Add(AddProductViewModel model)
        {
            Product product = new Product
            {
                Description= model.Description,
                Discount= model.Discount,
                Name= model.Name,
                Price= model.Price,
                ProductStatus= model.ProductStatus,
                VendorId= model.VendorId,
                
            };
            var categories = model.CategoryIds.Select(
                p => new Category { Id = p }).ToList();
            
            _categoryRepository.AttachRange(categories);

            product.Categories = categories;
            _productrepository.Add(product);
            _uow.SaveChanges();
        }

        public Tuple<int, List<ProductAdminListViewModel>> GetAllForAdmin(AdminProductFilter model)
        {
            var data = _productrepository.GetAll(model);
                
            var productList = data.Select(p=>new ProductAdminListViewModel
            {
                Id= p.Id,
                CategoryName = String.Join(",", p.Categories.Select(c=>c.Name)) ,
                Name= p.Name,
                Price= p.Price,
            }).ToList();


            var productCount = _productrepository.Count(model);
            var pageCount = (int)Math.Ceiling( (double)productCount / model.PageSize);
            return Tuple.Create(pageCount, productList);
        }

        public AddProductViewModel GetById(int Id)
        {
            var product = _productrepository.GetById(Id);
            return new AddProductViewModel
            {
                Id = product.Id,
                Description = product.Description,
                Discount = product.Discount,
                Name = product.Name,
                Price = product.Price,
                ProductStatus = product.ProductStatus,
                VendorId = product.VendorId,
                CategoryIds = product.Categories.Select(c => c.Id).ToList(),
            };
        }

        public void Update(AddProductViewModel model)
        {
            var categories = model.CategoryIds.Select(
                p => new Category { Id = p }).ToList();
            var productEntity = _productrepository.GetById(model.Id);

            productEntity.Description = model.Description;
            productEntity.Discount = model.Discount;
            productEntity.Name = model.Name;
            productEntity.Price = model.Price;
            productEntity.VendorId = model.VendorId;
            productEntity.ProductStatus = model.ProductStatus;

            // disable tracking
            foreach(var item in productEntity.Categories)
            {
                _categoryRepository.ChengeTracking(item);
            }
            productEntity.Categories.Clear();
            productEntity.Categories= categories;
            _categoryRepository.AttachRange(categories);
            _uow.SaveChanges();

        }
    }
}
