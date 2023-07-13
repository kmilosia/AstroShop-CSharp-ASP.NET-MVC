using AstroShop.Data.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace AstroShop.PortalWWW.Controllers
{
    public class ShopController : Controller
    {
        private readonly AstroShopContext _context;
        public ShopController(AstroShopContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(int? id,string searchString, string sortOrder)
        {
            ViewBag.NameSortParam = sortOrder == "name_desc" ? "name_asc" : "name_desc";
            ViewBag.PriceSortParam = sortOrder == "price_desc" ? "price_asc" : "price_desc";

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
            ViewBag.Type = await _context.Type.ToListAsync();

            if (id == null)
            {
                var first = await _context.Type.FirstAsync();
                id = first.IDType;
            }

            var products = from m in _context.Product
                           where m.IDType == id
                         select m;

            switch (sortOrder)
            {
                case "name_asc":
                    products = products.OrderBy(s => s.Name);
                    break;
                case "name_desc":
                    products = products.OrderByDescending(s => s.Name);
                    break;
                case "price_asc":
                    products = products.OrderBy(s => s.Price);
                    break;
                case "price_desc":
                    products = products.OrderByDescending(s => s.Price);
                    break;
                default:
                    products = products.OrderBy(s => s.Name);
                    break;
            }
            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(s => s.Name!.Contains(searchString));
            }
            return View(await products.ToListAsync());
        }     
        public async Task<IActionResult> Details(int? id) //id kliknietego towaru ktorego szczegoly mamy wyswietlic
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
            ViewBag.Type = await _context.Type.ToListAsync();
            //do widoku przekazujemy towar o danym id ktory kliknieto
            return View(await _context.Product.Where(p => p.IDProduct == id).FirstOrDefaultAsync());
        }
    }
}
