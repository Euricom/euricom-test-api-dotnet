using GraphQL.Types;

namespace ShopSchema
{
    public class BasketWhitoutCheckOutIdType : ObjectGraphType<BasketWhitoutCheckOutId>
    {
        public BasketWhitoutCheckOutIdType()
        {            
            Field("Basket", basketWhitoutCheckOutId => basketWhitoutCheckOutId.BasketItemsWhitProduct, true, typeof(ListGraphType<BasketItemWithProductType>)).Resolve(context =>
            {
                BasketWhitoutCheckOutId basketWhitoutCheckOutId = context.Source;
                return basketWhitoutCheckOutId.BasketItemsWhitProduct;
            });
        }
    }
}
