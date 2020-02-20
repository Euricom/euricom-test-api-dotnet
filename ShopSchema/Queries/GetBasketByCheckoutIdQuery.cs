using GraphQL.Types;

namespace ShopSchema
{
    public static class GetBasketByCheckoutIdQuery
    {
        public static BasketWithProductObjects GetBasketByCheckoutId(IProduct _product, IBasket _basket, ResolveFieldContext<object> context)
        {
            string checkoutId = context.GetArgument<string>("checkoutId");
            Basket basket = _basket.GetBasketByCheckoutId(checkoutId);
            

            BasketWhitoutCheckOutId basketWhitoutCheckOutId = ConvertBasketToBasketWithProductObjects.BasketConverter(_product, basket);

            return new BasketWithProductObjects(checkoutId, basketWhitoutCheckOutId.BasketItemsWhitProduct);
        }
    }
}
