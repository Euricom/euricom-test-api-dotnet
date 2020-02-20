using System.Collections.Generic;

namespace ShopSchema
{
    public class BasketWhitoutCheckOutId
    {        
        public List<BasketItemWithProduct> BasketItemsWhitProduct { get; set; }

        public BasketWhitoutCheckOutId(List<BasketItemWithProduct> basketItemsWhitProduct)
        {            
            BasketItemsWhitProduct = basketItemsWhitProduct;
        }
    }
}
