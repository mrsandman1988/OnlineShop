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
        public IActionResult Index(int pageSize = 1, int pageIndex = 1)
        {
            var data = _productService.GetAllForAdmin(pageSize, pageIndex);
            ViewBag.PageCount = data.Item1;
            ViewBag.PageIndex = pageIndex;
            return View(data.Item2);
        }
        [HttpGet]
        public IActionResult Add()
        {
            GetProductDropdownData();
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddProductViewModel model)
        {
            if(model.CategoryIds == null || model.CategoryIds.Count == 0)
            {
                ModelState.AddModelError(nameof(AddProductViewModel.CategoryIds),"Please select product categories");
            }
            if(!ModelState.IsValid)
            {
                GetProductDropdownData();
                return View(model);
            }
            _productService.Add(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        { 
            var model = _productService.GetById(id);
          GetProductDropdownData();
          return View(model);
        }

        [HttpPost]
        public IActionResult Edit(AddProductViewModel model)
        {
            _productService.Update(model);
            return RedirectToAction("Index");
        }

        private void GetProductDropdownData()
        {
            ViewBag.Categories = _categoryService.GetAll();
            ViewBag.Vendors = _vendorService.GetAll();
        }
    }
}
