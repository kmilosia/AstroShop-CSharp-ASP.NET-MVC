using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroShop.Data.Data.Shop
{
    public class Product  : BaseEntity
    {
        [Key]
        public int IDProduct { get; set; }
        [Required(ErrorMessage = "Code is required")]
        public string Code { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Price is required")]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }
        [Display(Name = "Choose image URL")]
        public string ImageURL { get; set; }
        public string Header { get; set; }
        public string Specifications { get; set; }
        public string Description { get; set; }
        [Display(Name = "Adding date")]
        public DateTime AddingDate { get; set; }
        [Display(Name = "Type")]
        public int? IDType { get; set; }

        [ForeignKey("IDType")]
        public virtual Type Type { get; set; }
    }
}
