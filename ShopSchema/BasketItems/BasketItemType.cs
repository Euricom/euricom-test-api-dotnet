using GraphQL.Types;

namespace ShopSchema
{
    public class BasketItemType: ObjectGraphType<BasketItem>
    {
        public BasketItemType()
        {
            Field(item => item.Id, true, typeof(GuidGraphType));
            Field(item => item.ProductId, true);
            Field(item => item.Quantity, true);
        }
    }
}
