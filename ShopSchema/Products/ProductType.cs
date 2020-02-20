using GraphQL.Types;

namespace ShopSchema
{
    public class ProductType : ObjectGraphType<Product>
    {
        public ProductType()
        {
            Field(product => product.Id, nullable: true);
            Field(product => product.Sku, nullable: true);
            Field(product => product.Title, nullable: true);
            Field(product => product.Desc, nullable: true);
            Field(product => product.Image, nullable: true);
            Field(product => product.Stocked, nullable: true);
            Field(product => product.BasePrice, nullable: true);
            Field(product => product.Price, nullable: true);
        }
    }
}
