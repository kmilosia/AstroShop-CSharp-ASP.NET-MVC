using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroShop.Data.Data.Shop
{
    public class Type : BaseEntity
    {
        [Key]
        public int IDType { get; set; }
        [Required(ErrorMessage = "Name is obligatory")]
        [MaxLength(100, ErrorMessage = "Maximal length is 100 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Description is obligatory")]
        public string Description { get; set; }
    }
}
