using GraphQL.Types;

namespace ShopSchema
{
    public class BasketType : ObjectGraphType<Basket>
    {
        public BasketType()
        {
            Field(basket => basket.CheckoutId, true);
            Field(basket => basket.BasketItems, true, typeof(ListGraphType<BasketItemType>)).Resolve(context =>
            {
                Basket basket = context.Source;
                return basket.BasketItems;
            });
        }        
    }
}
