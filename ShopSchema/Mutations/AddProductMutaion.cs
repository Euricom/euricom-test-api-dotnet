using GraphQL.Types;

namespace ShopSchema
{
    public static class AddProductMutaion
    {
        public static Product AddProduct(IProduct _product, ResolveFieldContext<object> context)
        {
            Product productToAdd = context.GetArgument<Product>("product");
            Product product = _product.AddProduct(productToAdd);

            return product;
        }
    }
}
