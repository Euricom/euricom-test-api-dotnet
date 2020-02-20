using GraphQL;
using GraphQL.Types;
using ShopSchema.Exceptions;

namespace ShopSchema
{
    public static class AddItemToBasketMutation
    {
        public static BasketWhitoutCheckOutId AddItemToBasket(IProduct _product, IBasket _basket, ResolveFieldContext<object> context)
        {
            try
            {
                string checkoutId = context.GetArgument<string>("checkoutId");
                int productId = context.GetArgument<int>("productId");
                Basket basket = _basket.AddItemToBasket(checkoutId, productId);

                return ConvertBasketToBasketWithProductObjects.BasketConverter(_product, basket);
            }  
            catch(BusinessException ex)
            {
                context.Errors.Add(new ExecutionError(ex.Message));

                return null;
            }
        }
    }
}
