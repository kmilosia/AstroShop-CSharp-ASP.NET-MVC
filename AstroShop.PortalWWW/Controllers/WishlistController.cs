using AstroShop.Data.Data;
using AstroShop.PortalWWW.Models.BusinessLogic;
using AstroShop.PortalWWW.Models.Shop;
using Microsoft.AspNetCore.Mvc;

namespace AstroShop.PortalWWW.Controllers
{
    public class WishlistController : Controller
    {
        public readonly AstroShopContext _context;
        public WishlistController(AstroShopContext context)
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
            WishlistBusiness wishlistBusiness = new WishlistBusiness(this._context, this.HttpContext);
            var wishlistData = new WishlistData
            {
                WishlistElements = await wishlistBusiness.GetWishlistElements(),
            };
            return View(wishlistData);
        }
        public async Task<IActionResult> AddToWishlist(int id)
        {
            WishlistBusiness wishlistBusiness = new WishlistBusiness(this._context, this.HttpContext);
            wishlistBusiness.AddToWishlist(await _context.Product.FindAsync(id));
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> RemoveFromWishlist(int id)
        {
            WishlistBusiness wishlistBusiness = new WishlistBusiness(this._context, this.HttpContext);
            wishlistBusiness.RemoveFromWishlist(await _context.Product.FindAsync(id));
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> MoveToCart()
        {
            WishlistBusiness wishlistBusiness = new WishlistBusiness(_context, HttpContext);
            CartBusiness cartBusiness = new CartBusiness(_context, HttpContext);

            var wishlistElements = await wishlistBusiness.GetWishlistElements();

            foreach (var wishlistElement in wishlistElements)
            {
                 cartBusiness.AddToCart(wishlistElement.Product);
                 wishlistBusiness.RemoveFromWishlist(wishlistElement.Product);
            }

            return RedirectToAction("Index", "Cart");
        }
        public async Task<IActionResult> AddToCartAndRemoveFromWishlist(int id)
        {
            WishlistBusiness wishlistBusiness = new WishlistBusiness(this._context, this.HttpContext);
            CartBusiness cartBusiness = new CartBusiness(this._context, this.HttpContext);

            // Add the product to the cart
            var product = await _context.Product.FindAsync(id);
            cartBusiness.AddToCart(product);

            // Remove the product from the wishlist
            wishlistBusiness.RemoveFromWishlist(product);

            return RedirectToAction("Index", "Cart");
        }
    }
}
