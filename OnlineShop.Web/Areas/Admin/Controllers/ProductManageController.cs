using Microsoft.AspNetCore.Mvc;
using OnlineShop.Core.Interfaces;
using OnlineShop.Core.ViewModels;

namespace OnlineShop.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductManageController : Controller
    {
        private readonly IProductService _productService;
        private readonly IVendorService _vendorService;
        private readonly ICategoryService _categoryService;
        public ProductManageController(IProductService productService, IVendorService vendorService, ICategoryService categoryService)
        {
            _productService = productService;
            _vendorService = vendorService;
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {
            var data = _productService.GetAllForAdmin();
            return View(data);
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Categories = _categoryService.GetAll();
            ViewBag.Vendors = _vendorService.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddProductViewModel model)
        {
            return RedirectToAction("Index");
        }
    }
}
