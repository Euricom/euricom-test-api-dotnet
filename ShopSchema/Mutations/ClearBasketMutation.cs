using GraphQL.Types;

namespace ShopSchema
{
    public static class ClearBasketMutation
    {
        public static BasketWhitoutCheckOutId ClearBasket(IProduct _product, IBasket _basket, ResolveFieldContext<object> context)
        {
            string checkoutId = context.GetArgument<string>("checkoutId");
            Basket basket = _basket.ClearBasket(checkoutId);

            return ConvertBasketToBasketWithProductObjects.BasketConverter(_product, basket);
        }
    }
}
