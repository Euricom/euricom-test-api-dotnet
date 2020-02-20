using GraphQL.Types;

namespace ShopSchema
{
    public class ProductInputType : InputObjectGraphType<Product>
    {
        public ProductInputType()
        {
            Field("Id", product => product.Id, nullable: true, type: typeof(IntGraphType));
            Field("Sku", product => product.Sku, nullable: false, type: typeof(StringGraphType));
            Field("Title", product => product.Title, nullable: false, type: typeof(StringGraphType));
            Field("Desc", product => product.Desc, nullable: true, type: typeof(StringGraphType));
            Field("Image", product => product.Image, nullable: true, type: typeof(StringGraphType));
            Field("Stocked", product => product.Stocked, nullable: true, type: typeof(BooleanGraphType));
            Field("BasePrice", product => product.BasePrice, nullable: true, type: typeof(DecimalGraphType));
            Field("Price", product => product.Price, nullable: false, type: typeof(DecimalGraphType));
        }
    }
}
