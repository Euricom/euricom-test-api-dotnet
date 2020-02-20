using System;
using System.Collections.Generic;
using System.Text;

namespace ShopSchema.Exceptions
{
    public class ProductNotFoundException : BusinessException
    {
        public ProductNotFoundException(int productId) : base($"The product with id {productId} was not found.", "product_not_found") { }
    }
}
