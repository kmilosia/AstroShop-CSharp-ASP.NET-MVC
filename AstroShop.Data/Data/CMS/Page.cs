using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroShop.Data.Data.CMS
{
    public class Page : BaseEntity
    {
        [Key]
        public int IDPage { get; set; }
        [Required(ErrorMessage = "Title of the link is obligatory")]
        [MaxLength(50, ErrorMessage = "Link title cannot be longer than 30 characters")]
        [Display(Name = "Title of the page link")]
        public string LinkTitle { get; set; }
        [Required(ErrorMessage = "Title is obligatory")]
        public string Title { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string Content { get; set; }
        [Required(ErrorMessage = "Display position is obligatory")]
        [Display(Name = "Position of display")]
        public int DisplayPosition { get; set; }
    }
}
