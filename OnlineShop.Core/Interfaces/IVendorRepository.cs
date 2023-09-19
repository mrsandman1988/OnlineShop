using OnlineShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.Interfaces
{
    public interface IVendorRepository
    {
        void Add(Vendor vendor);
        Vendor GetById(int id);
        List<Vendor> GetAll();
        void Delete(Vendor vendor);
    }
}
