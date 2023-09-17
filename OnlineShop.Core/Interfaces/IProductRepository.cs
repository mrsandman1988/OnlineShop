using OnlineShop.Core.Entities;
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
        List<Product> GetAll();
        void Delete(Product product);
    }
}
