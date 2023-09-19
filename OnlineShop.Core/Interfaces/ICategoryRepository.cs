using OnlineShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.Interfaces
{
    public interface ICategoryRepository
    {
        void Add(Category category);
        Category GetById(int id);
        List<Category> GetAll();
        void Delete(Category category);
    }
}
