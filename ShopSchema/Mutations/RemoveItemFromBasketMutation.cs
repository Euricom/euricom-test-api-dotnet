using GraphQL.Types;

namespace ShopSchema
{
    public static class RemoveItemFromBasketMutation
    {
        public static BasketWhitoutCheckOutId RemoveItemFromBasket(IProduct _product, IBasket _basket, ResolveFieldContext<object> context)
        {
            string checkoutId = context.GetArgument<string>("checkoutId");
            int productId = context.GetArgument<int>("productId");
            Basket basket = _basket.RemoveItemFromBasket(checkoutId, productId);

            return ConvertBasketToBasketWithProductObjects.BasketConverter(_product, basket);
        }
    }
}
