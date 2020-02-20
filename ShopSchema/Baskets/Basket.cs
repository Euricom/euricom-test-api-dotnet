using System.Collections.Generic;

namespace ShopSchema
{
    public class Basket
    {
        public string CheckoutId { get; set; } 
        public List<BasketItem> BasketItems { get; set; }

        public Basket(string checkoutId, List<BasketItem> basketItems)
        {
            CheckoutId = checkoutId;
            BasketItems = basketItems;
        }
    }
}
