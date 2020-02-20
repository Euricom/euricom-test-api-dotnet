using GraphQL.Types;

namespace ShopSchema
{
    public class BasketWithProductObjectsType : ObjectGraphType<BasketWithProductObjects>
    {
        public BasketWithProductObjectsType()
        {                       
            Field(basketWithProductObjects => basketWithProductObjects.CheckoutId, true);
            Field("Basket",  basketWithProductObjects => basketWithProductObjects.BasketItemsWhitProduct, true, typeof(ListGraphType<BasketItemWithProductType>)).Resolve(context =>
            {
                BasketWithProductObjects basketWithProductObjects = context.Source;
                return basketWithProductObjects.BasketItemsWhitProduct;
            });
        }
    }
}
