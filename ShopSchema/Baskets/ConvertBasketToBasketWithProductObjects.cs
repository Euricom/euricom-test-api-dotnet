using System.Collections.Generic;
using System.Linq;

namespace ShopSchema
{
    public class ConvertBasketToBasketWithProductObjects
    {
        public static BasketWhitoutCheckOutId BasketConverter(IProduct _product, Basket basket)
        {
            BasketWhitoutCheckOutId basketWhitoutCheckOutId = new BasketWhitoutCheckOutId(new List<BasketItemWithProduct>());

            foreach (BasketItem item in basket.BasketItems)
            {
                Product product = _product.AllProducts.SingleOrDefault(prod => prod.Id == item.ProductId);
                if (product != null)
                {
                    basketWhitoutCheckOutId.BasketItemsWhitProduct.Add(new BasketItemWithProduct(item.Id, product, item.Quantity));
                }
            }

            return basketWhitoutCheckOutId;
        }
    }
}
