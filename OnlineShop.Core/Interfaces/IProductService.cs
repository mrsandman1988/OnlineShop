using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.Core.ViewModels;
using OnlineShop.Core.ViewModels.Products;

namespace OnlineShop.Core.Interfaces
{
    public interface IProductService
    {
       Tuple<int, List<ProductAdminListViewModel>> GetAllForAdmin(AdminProductFilter model);
        void Add(AddProductViewModel model);
        AddProductViewModel GetById(int Id);
        void Update(AddProductViewModel model);
    }
}
