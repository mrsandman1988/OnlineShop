using Microsoft.EntityFrameworkCore;
using OnlineShop.Core.Entities;
using OnlineShop.Core.Interfaces;
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

        public List<Product> GetAll()
        {
            return _context.Products
                
                .Include(p=>p.Categories)
                .ToList();
        }

        public Product GetById(int id)
        {
            return _context.Products.Include(p=>p.Categories).
                FirstOrDefault(p=>p.Id == id);
        }

        public int Count()
        {
            return _context.Products.Count();
        }
    }
}
