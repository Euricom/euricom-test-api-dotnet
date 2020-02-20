using GraphQL.Types;

namespace ShopSchema
{
    public class SchemaShop : Schema
    {
        public SchemaShop(IBasket _basket, IProduct _product)
        {
            Query = new QueryShop(_product, _basket);
            Mutation = new MutationShop(_product, _basket);
        }
    }
}
