using OnlineShop.Core.Interfaces;
using OnlineShop.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository= categoryRepository;
        }
        public List<CategoryViewModel> GetAll()
        {
            var data = _categoryRepository.GetAll();
            return data.Select(x => new CategoryViewModel
            {
                Name = x.Name,
                Id = x.Id
            }).ToList();
        }
    }
}
