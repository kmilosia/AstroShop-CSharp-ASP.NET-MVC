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
    public class Blog : BaseEntity
    {
        [Key]
        public int IDBlog { get; set; }
        [Required(ErrorMessage = "Title of the link is obligatory")]
        [MaxLength(50, ErrorMessage = "Link title cannot be longer than 30 characters")]
        [Display(Name = "Title of the blog link")]
        public string LinkTitle { get; set; }
        [Required(ErrorMessage = "Title is obligatory")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Heading is obligatory")]
        [Display(Name = "Heading Card Text")]
        public string Heading { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string Content { get; set; }
        [Display(Name = "Choose image URL")]
        public string ImageURL { get; set; }
        public string Author { get; set; }
        [Display(Name = "News' subject category")]
        public string Category { get; set; }
        [Display(Name = "Creation date")]
        public DateTime CreationDate { get; set; }
        [Display(Name = "Type")]
        public int? IDBlogType { get; set; }
        [ForeignKey("IDBlogType")]
        public virtual BlogType BlogType { get; set; }
    }
}
