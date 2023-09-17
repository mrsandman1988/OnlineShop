using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.Entities
{
    public class Cart
    {
        public int Id { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public int Count { get; set; }
        public int? Price { get; set; }
        public string UniqueId { get; set; }
        public Product Product { get; set; }
        public DateTime AddedDate { get; set; }
    }
}
