using OnlineShop.Core.Entities;
using OnlineShop.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Infrastructure.Repositories
{
    public class VendorRepository : IVendorRepository
    {
        private readonly OnlineShopDbContext _context;

        public VendorRepository(OnlineShopDbContext context)
        {
            _context= context;
        }
        public void Add(Vendor vendor)
        {
           _context.Vendors.Add(vendor);
        }

        public void Delete(Vendor vendor)
        {
           _context.Vendors.Remove(vendor);
        }

        public List<Vendor> GetAll()
        {
            return _context.Vendors.ToList();
        }

        public Vendor GetById(int id)
        {
            return _context.Vendors.Find(id);
        }
    }
}
