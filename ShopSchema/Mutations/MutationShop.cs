using GraphQL.Types;

namespace ShopSchema
{
    public class MutationShop : ObjectGraphType<object>
    {
        public MutationShop(IProduct _product, IBasket _basket)
        {
            Field<ProductType>("addProduct",
               arguments: new QueryArguments(
                   new QueryArgument<ProductInputType> { Name = "product" }
               ),
               resolve: context => AddProductMutaion.AddProduct(_product, context)
            );

            Field<ListGraphType<ProductType>>("deleteProduct",
               arguments: new QueryArguments(
                   new QueryArgument<IntGraphType> { Name = "id" }
               ),
               resolve: context => DeleteProductMutation.DeleteProduct(_product, context)
            );

            Field<BasketWhitoutCheckOutIdType>("addItemToBasket",
               arguments: new QueryArguments(
                   new QueryArgument<StringGraphType> { Name = "checkoutId"},
                   new QueryArgument<IntGraphType> { Name = "productId" }
               ),
               resolve: context => AddItemToBasketMutation.AddItemToBasket(_product, _basket, context)
            );

            Field<BasketWhitoutCheckOutIdType>("removeItemFromBasket",
               arguments: new QueryArguments(
                   new QueryArgument<StringGraphType> { Name = "checkoutId" },
                   new QueryArgument<IntGraphType> { Name = "productId" }
               ),
               resolve: context => RemoveItemFromBasketMutation.RemoveItemFromBasket(_product, _basket, context)
            );

            Field<BasketWhitoutCheckOutIdType>("clearBasket",
               arguments: new QueryArguments(
                   new QueryArgument<StringGraphType> { Name = "checkoutId" }                 
               ),
               resolve: context => ClearBasketMutation.ClearBasket(_product, _basket, context)
            );
        }
    }
}
