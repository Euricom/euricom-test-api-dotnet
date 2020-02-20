using System;
using System.Collections.Generic;
using System.Text;

namespace ShopSchema.Exceptions
{
    public class ProductIsNotStockedException : BusinessException
    {
        public ProductIsNotStockedException(int productId) : base($"The product with id {productId} is not stocked.", "product_is_not_stocked") { }
    }
}
