using Microsoft.AspNetCore.Mvc;
using OnlineShop.Core.Interfaces;

namespace OnlineShop.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductManageController : Controller
    {
        private readonly IProductService _productService;
        public ProductManageController(IProductService productService)
        {
            _productService = productService;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
