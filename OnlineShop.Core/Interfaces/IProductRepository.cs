using OnlineShop.Core.Entities;
using OnlineShop.Core.ViewModels.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.Interfaces
{
    public interface IProductRepository
    {
        void Add(Product product);
        Product GetById(int id);
        List<Product> GetAll(AdminProductFilter model);
        void Delete(Product product);
        int Count(AdminProductFilter model);
    }
}
