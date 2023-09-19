using OnlineShop.Core.Interfaces;
using OnlineShop.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.Services
{
    public class VendorService : IVendorService
    {
        private readonly IVendorRepository _vendorRepository;

        public VendorService(IVendorRepository vendorRepository)
        {
            _vendorRepository = vendorRepository;
        }

        public List<VendorViewModel> GetAll()
        {
            var data = _vendorRepository.GetAll();
            return data.Select(v => new VendorViewModel
            {
                Id= v.Id,
                Name=v.Name
            }).ToList();
        }
    }
}
