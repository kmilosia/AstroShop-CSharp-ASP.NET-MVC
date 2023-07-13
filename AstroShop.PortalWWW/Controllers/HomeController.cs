using AstroShop.Data.Data;
using AstroShop.Data.Data.CMS;
using AstroShop.PortalWWW.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AstroShop.PortalWWW.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AstroShopContext _context;
        private readonly List<News> _news;

        public HomeController(AstroShopContext context)
        {
            _context = context;
        }

        public IActionResult Index(int? id)
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
            if (id == null)
            {
                id = _context.Page.First().IDPage;
            }
            var item = _context.Page.Find(id);
            return View(item);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult About(int? id)
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
                           ).ToList(); var item = _context.Page.Find(id);
            return View(item);
        }
        public IActionResult Contact(int? id)
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
            var item = _context.Page.Find(id);
            return View(item);
        }
        public IActionResult Products(int? id)
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
            var item = _context.Page.Find(id);
            return View(item);
        }
        public async Task<IActionResult> News(int id)
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
        public IActionResult Guides(int? id)
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
            var item = _context.Page.Find(id);
            return View(item);
        }
        public IActionResult Articles(int? id)
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
            var item = _context.Page.Find(id);
            return View(item);
        }      

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}