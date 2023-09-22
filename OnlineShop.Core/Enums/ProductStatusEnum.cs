using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace OnlineShop.Core.Enums
{
    public enum ProductStatusEnum
    {
        New = 1,
        [Display(Name = "Best Buy")]
        Best_Buy = 2,
        Popular = 3
    }
}
