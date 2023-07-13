using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AstroShop.Data.Data.CMS
{
    public class FooterLinks : BaseEntity
    {
        [Key]
        public int IDFooterLinks { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        [Display(Name = "Link title")]
        [Required]
        public string LinkTitle { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        [Required]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Display position")]
        public int DisplayPosition { get; set; }
    }
}
