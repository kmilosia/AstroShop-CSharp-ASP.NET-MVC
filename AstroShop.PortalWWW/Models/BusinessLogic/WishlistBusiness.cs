using AstroShop.Data.Data.Shop;
using AstroShop.Data.Data;
using Microsoft.EntityFrameworkCore;

namespace AstroShop.PortalWWW.Models.BusinessLogic
{
    public class WishlistBusiness
    {
        private readonly AstroShopContext _context;
        private string IDWishlistSession;
        public WishlistBusiness(AstroShopContext context, HttpContext httpContext)
        {
            _context = context;
            IDWishlistSession = GetIDWishlistSession(httpContext);
        }
        private string GetIDWishlistSession(HttpContext httpContext)
        {
            if (httpContext.Session.GetString("IDWishlistSession") == null)
            {
                if (!string.IsNullOrWhiteSpace(httpContext.User.Identity.Name))
                {
                    httpContext.Session.SetString("IDWishlistSession", httpContext.User.Identity.Name);
                }
                else
                {
                    Guid tempIDWishlistSession = Guid.NewGuid();
                    httpContext.Session.SetString("IDWishlistSession", tempIDWishlistSession.ToString());
                }
            }
            return httpContext.Session.GetString("IDWishlistSession").ToString();

        }
        public void AddToWishlist(Product product)
        {
            var wishlistElement =
                (
                    from element in _context.WishlistElement
                    where element.IDProduct == product.IDProduct && element.IDWishlistSession == this.IDWishlistSession
                    select element
                ).FirstOrDefault();
            if (wishlistElement == null)
            {
                wishlistElement = new WishlistElement()
                {
                    IDWishlistSession = this.IDWishlistSession,
                    IDProduct = product.IDProduct,
                    Product = _context.Product.Find(product.IDProduct),
                    CreationDate = DateTime.Now,
                };
                _context.WishlistElement.Add(wishlistElement);
            }
            else
            {
            }
            _context.SaveChanges();
        }
        public void RemoveFromWishlist(Product product)
        {
            var wishlistElement =
                (
                    from element in _context.WishlistElement
                    where element.IDProduct == product.IDProduct && element.IDWishlistSession == this.IDWishlistSession
                    select element
                ).FirstOrDefault();

            if (wishlistElement != null)
            {               
                 _context.WishlistElement.Remove(wishlistElement);               
                _context.SaveChanges();
            }
        }
        public async Task<List<WishlistElement>> GetWishlistElements()
        {
            return await
                _context.WishlistElement.Where(e => e.IDWishlistSession == this.IDWishlistSession).Include(e => e.Product).ToListAsync();
        }      
    }
}
