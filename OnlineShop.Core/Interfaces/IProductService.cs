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
        List<ProductAdminListViewModel> GetAllForAdmin();
    }
}
