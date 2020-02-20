using GraphQL.Types;

namespace ShopSchema
{
    public class BasketItemWithProductType : ObjectGraphType<BasketItemWithProduct>
    {
        public BasketItemWithProductType()
        {
            Field(itemWithProduct => itemWithProduct.Id, true, typeof(GuidGraphType));
            Field(itemWithProduct => itemWithProduct.Product, true, typeof(ProductType)).Resolve(context =>
            {
                BasketItemWithProduct itemWithProduct = context.Source;
                return itemWithProduct.Product;

            });
            Field(itemWithProduct => itemWithProduct.Quantity, true);
        }
    }
}
