using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroShop.Data.Data.Shop
{
    public class WishlistElement
    {
        [Key]
        public int IDWishlistElement { get; set; }
        public string IDWishlistSession { get; set; }
        public int IDProduct { get; set; }
        public Product Product { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
