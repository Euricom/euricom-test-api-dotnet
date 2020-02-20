using System.Collections.Generic;

namespace ShopSchema
{
    public class BasketWithProductObjects
    {
        public string CheckoutId { get; set; }
        public List<BasketItemWithProduct> BasketItemsWhitProduct { get; set; }

        public BasketWithProductObjects(string checkoutId, List<BasketItemWithProduct> basketItemsWhitProduct)
        {
            CheckoutId = checkoutId;
            BasketItemsWhitProduct = basketItemsWhitProduct;
        }
    }
}
