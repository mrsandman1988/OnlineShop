using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.Core.ViewModels;
namespace OnlineShop.Core.Interfaces
{
    public interface IProductService
    {
       Tuple<int, List<ProductAdminListViewModel>> GetAllForAdmin(int pageSize, int pageIndex);
        void Add(AddProductViewModel model);
        AddProductViewModel GetById(int Id);
        void Update(AddProductViewModel model);
    }
}
