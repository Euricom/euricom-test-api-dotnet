using GraphQL.Types;    

namespace ShopSchema
{
   public  class QueryShop : ObjectGraphType
    {
        public QueryShop(IProduct _product, IBasket _basket)
        {
            Field<ListGraphType<ProductType>>("allProducts", arguments: new QueryArguments(
                    new QueryArgument<AllProductsInputType> { Name = "ordering" }
                 ),
                 resolve: context => GetAllProductsQuery.GetAllProducts(_product, context)
            );

            Field<ProductType>("product",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "id" }
                ),
                resolve: context => GetProductByIdQuery.GetProductById(_product, context)
            );

            Field<BasketWithProductObjectsType>("basket",
                arguments: new QueryArguments(
                    new QueryArgument<StringGraphType> {Name = "checkoutId"}
                    ),
                resolve: context => GetBasketByCheckoutIdQuery.GetBasketByCheckoutId(_product, _basket, context)
                );
        }
    }
}
