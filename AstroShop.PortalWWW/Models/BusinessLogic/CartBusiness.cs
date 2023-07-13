using AstroShop.Data.Data;
using AstroShop.Data.Data.Shop;
using Microsoft.EntityFrameworkCore;

namespace AstroShop.PortalWWW.Models.BusinessLogic
{
    public class CartBusiness
    {
        private readonly AstroShopContext _context;
        private string IDCartSession;
        public CartBusiness(AstroShopContext context, HttpContext httpContext)
        {
            _context = context;
            IDCartSession = GetIDCartSession(httpContext);
        }
        private string GetIDCartSession(HttpContext httpContext)
        {
            if(httpContext.Session.GetString("IDCartSession") == null)
            {
                if(!string.IsNullOrWhiteSpace(httpContext.User.Identity.Name))
                {
                    httpContext.Session.SetString("IDCartSession", httpContext.User.Identity.Name);
                }
                else
                {
                    Guid tempIDCartSession = Guid.NewGuid();
                    httpContext.Session.SetString("IDCartSession", tempIDCartSession.ToString());
                }
            }
            return httpContext.Session.GetString("IDCartSession").ToString();

        }
        public void AddToCart(Product product)
        {
            var cartElement =
                (
                    from element in _context.CartElement
                    where element.IDProduct == product.IDProduct && element.IDCartSession == this.IDCartSession
                    select element
                ).FirstOrDefault();
            if (cartElement == null)
            {
                cartElement = new CartElement()
                {
                    IDCartSession = this.IDCartSession,
                    IDProduct = product.IDProduct,
                    Product = _context.Product.Find(product.IDProduct),
                    Quantity = 1,
                    CreationDate = DateTime.Now,
                };
                _context.CartElement.Add(cartElement);
            }
            else
            {
                cartElement.Quantity++;
            }
            _context.SaveChanges();
        }
        public void RemoveFromCart(Product product)
        {
            var cartElement =
                (
                    from element in _context.CartElement
                    where element.IDProduct == product.IDProduct && element.IDCartSession == this.IDCartSession
                    select element
                ).FirstOrDefault();

            if (cartElement != null)
            {
                if (cartElement.Quantity > 1)
                {
                    cartElement.Quantity--;
                }
                else
                {
                    _context.CartElement.Remove(cartElement);
                }
                _context.SaveChanges();
            }
        }
        public async Task<List<CartElement>> GetCartElements()
        {
            return await
                _context.CartElement.Where(e=>e.IDCartSession==this.IDCartSession).Include(e=>e.Product).ToListAsync();
        }
        public async Task<decimal> GetTotal()
        {
            var items =
            (
                from element in _context.CartElement
                where element.IDCartSession == this.IDCartSession
                select (decimal?)element.Quantity * element.Product.Price
            );
            return await items.SumAsync() ?? 0; 
        }
    }
}
