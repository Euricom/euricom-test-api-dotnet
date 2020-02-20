using GraphQL;
using GraphQL.Types;
using ShopSchema.Exceptions;

namespace ShopSchema
{
    public static class GetProductByIdQuery
    {
        public static Product GetProductById(IProduct _product, ResolveFieldContext<object> context)
        {
            try
            {
                int id = context.GetArgument<int>("id");
                Product product = _product.GetProductById(id);
                return product;
            }
            catch(BusinessException ex)
            {
                context.Errors.Add(new ExecutionError(ex.Message));

                return null;
            }
        }
    }
}
