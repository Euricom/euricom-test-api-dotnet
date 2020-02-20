using GraphQL;
using GraphQL.Types;
using ShopSchema.Exceptions;
using System;
using System.Collections.Generic;

namespace ShopSchema
{
    public static class GetAllProductsQuery
    {
        public static List<Product> GetAllProducts(IProduct _product, ResolveFieldContext<object> context)
        {
            AllProductsInput allProductsInput = context.GetArgument<AllProductsInput>("ordering");
            if (allProductsInput == null)
            {
                return _product.AllProducts;
            }

            try
            {
                List<Product> products = _product.GetAllProducts(allProductsInput.OrderBy, allProductsInput.Page, allProductsInput.PageSize);
                
                return products;
            }            
            catch(BusinessException ex)
            {
                context.Errors.Add(new ExecutionError(ex.Message));

                return null;
            }            
        }
    }
}
