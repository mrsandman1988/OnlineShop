using OnlineShop.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace OnlineShop.Core.ViewModels
{
    public class AddProductViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Please enter product name")]
        [MinLength(4,ErrorMessage = "Product name min length is 4")]
        [MaxLength(50)]
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int? Discount { get; set; }
        public ProductStatusEnum ProductStatus { get; set; }
        public int VendorId { get; set; }
        public List<int> CategoryIds { get; set; }
    }
}
