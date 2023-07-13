using AstroShop.Data.Data;
using AstroShop.PortalWWW.Models.BusinessLogic;
using AstroShop.PortalWWW.Models.Shop;
using Microsoft.AspNetCore.Mvc;

namespace AstroShop.PortalWWW.Controllers
{
    public class CartController : Controller
    {
        public readonly AstroShopContext _context;
        public CartController(AstroShopContext context)
        {
            this._context = context;
        }
        public async Task<IActionResult> Index()
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
            CartBusiness cartBusiness = new CartBusiness(this._context, this.HttpContext);
            var cartData = new CartData
            {
                CartElements = await cartBusiness.GetCartElements(),
                Total = await cartBusiness.GetTotal()
            };
            return View(cartData);
        }
        public async Task<IActionResult> Checkout()
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
            CartBusiness cartBusiness = new CartBusiness(this._context, this.HttpContext);
            var cartData = new CartData
            {
                CartElements = await cartBusiness.GetCartElements(),
                Total = await cartBusiness.GetTotal()
            };
            return View(cartData);
        }
        public async Task<IActionResult> AddToCart(int id)
        {
            CartBusiness cartBusiness = new CartBusiness(this._context, this.HttpContext);
            cartBusiness.AddToCart(await _context.Product.FindAsync(id));
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> RemoveFromCart(int id)
        {
            CartBusiness cartBusiness = new CartBusiness(this._context, this.HttpContext);
            cartBusiness.RemoveFromCart(await _context.Product.FindAsync(id));
            return RedirectToAction("Index");
        }
    }
}
