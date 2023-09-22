using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.ViewModels.Products
{
    public class AdminProductFilter
    {
        public string Name { get; set; }
        public int? CategoryId { get; set; }
        public int? FromPrice { get; set; }
        public int? ToPrice { get; set; }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public int SkipedCount
        {
            get
            {
                return (PageIndex - 1) * PageSize;
            }
        }
    }
}
