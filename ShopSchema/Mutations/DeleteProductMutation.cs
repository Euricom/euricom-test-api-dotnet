using GraphQL.Types;
using System.Collections.Generic;

namespace ShopSchema
{
    public class DeleteProductMutation
    {
        public static List<Product> DeleteProduct(IProduct _product, ResolveFieldContext<object> context)
        {
            int id = context.GetArgument<int>("id");
            List<Product> products = _product.DeleteProductById(id);

            return products;
        }
    }
}
