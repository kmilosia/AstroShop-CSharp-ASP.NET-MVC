using AstroShop.Data.Data;
using Microsoft.AspNetCore.Mvc;

namespace AstroShop.PortalWWW.Controllers
{
    public class NewsController : Controller
    {
        private readonly AstroShopContext _context;
        public NewsController(AstroShopContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(int id)
        {
            ViewBag.FooterLinksModel =
               (
                   from link in _context.FooterLinks
                   orderby link.DisplayPosition
                   select link
               ).ToList();
            ViewBag.ContactLinksModel =
               (
                   from link in _context.ContactLinks
                   orderby link.DisplayPosition
                   select link
               ).ToList();
            ViewBag.ProductsLinksModel =
               (
                   from link in _context.ProductsLinks
                   orderby link.DisplayPosition
                   select link
               ).ToList();
            ViewBag.SocialLinksModel =
               (
                   from link in _context.SocialLinks
                   orderby link.DisplayPosition
                   select link
               ).ToList();
            
            ViewBag.PageModel =
                (
                    from page in _context.Page
                    orderby page.DisplayPosition
                    select page
                ).ToList();
            ViewBag.NewsModel =
                (
                    from news in _context.News
                    orderby news.CreationDate
                    select news
                ).ToList();
            
            var item = await _context.News.FindAsync(id);
            return View(item);
        }
    }
}
