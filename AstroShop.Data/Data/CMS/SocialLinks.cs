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
    public class SocialLinks : BaseEntity
    {
        [Key]
        public int IDSocialLinks { get; set; }
        [Required]
        public string Title { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        [Display(Name = "Adress URL")]
        [Required]
        public string URLAdress { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        [Required]
        public string Icon { get; set; }
        [Required]
        [Display(Name = "Display position")]
        public int DisplayPosition { get; set; }
    }
}
