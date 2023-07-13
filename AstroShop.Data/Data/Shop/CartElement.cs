using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroShop.Data.Data.Shop
{
    public class CartElement
    {
        [Key]
        public int IDCartElement { get; set; }
        public string IDCartSession { get; set; }
        public int IDProduct { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
