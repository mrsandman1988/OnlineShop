using Azure;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Core.Entities;
using OnlineShop.Core.Interfaces;
using OnlineShop.Core.ViewModels.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly OnlineShopDbContext _context;
        public ProductRepository(OnlineShopDbContext context)
        {
            _context = context;
        }
        public void Add(Product product)
        {
           _context.Products.Add(product);

        }

        public void Delete(Product product)
        {
            _context.Products.Remove(product);
        }

        public List<Product> GetAll(AdminProductFilter model)
        {
            var baseQuery = BaseQuery(model);
            return baseQuery
                .OrderByDescending(p => p.Id)
                .Skip(model.SkipedCount)
                .Take(model.PageSize)
                .Include(p=>p.Categories)
                .ToList();
        }

        public Product GetById(int id)
        {
            return _context.Products.Include(p=>p.Categories).
                FirstOrDefault(p=>p.Id == id);
        }

        public int Count(AdminProductFilter model)
        {
            var baseQuery = BaseQuery(model);
            return baseQuery.Count();
        }

        private IQueryable<Product> BaseQuery(AdminProductFilter model)
        {
            // refactoring
            return _context.Products
                .Where(p => (model.Name == null || p.Name.ToLower().Contains(model.Name.ToLower()))
                 && (!model.FromPrice.HasValue || p.Price >= model.FromPrice)
                 && (!model.ToPrice.HasValue || p.Price <= model.ToPrice)
                 && (model.CategoryId == null || p.Categories.Any(c => c.Id == model.CategoryId)));
        }
    }
}
