using AstroShop.Data.Data.Shop;

namespace AstroShop.PortalWWW.Models.Shop
{
    //helper class to display cart properly
    public class CartData
    {
        public List<CartElement> CartElements { get; set; }
        public decimal Total { get; set; }

    }
}
