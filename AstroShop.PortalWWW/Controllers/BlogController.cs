using AstroShop.Data.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AstroShop.PortalWWW.Controllers
{
    public class BlogController : Controller
    {
        private readonly AstroShopContext _context;
        public BlogController(AstroShopContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(int? id) 
        {
            ViewBag.PageModel =
               (
                   from page in _context.Page
                   orderby page.DisplayPosition
                   select page
               ).ToList();
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
            ViewBag.BlogType = await _context.BlogType.ToListAsync(); 
                                                            
            if (id == null)
            {
                var first = await _context.BlogType.FirstAsync();
                id = first.IDBlogType;
            }
            return View(await _context.Blog.Where(p => p.IDBlogType == id).ToListAsync());
        }
        public async Task<IActionResult> Details(int? id)
        {
            ViewBag.PageModel =
               (
                   from page in _context.Page
                   orderby page.DisplayPosition
                   select page
               ).ToList();
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
            ViewBag.BlogType = await _context.BlogType.ToListAsync();
            return View(await _context.Blog.Where(p => p.IDBlog == id).FirstOrDefaultAsync());
        }
    }
}
