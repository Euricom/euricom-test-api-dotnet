using GraphQL.Types;

namespace ShopSchema
{
    public class AllProductsInputType : InputObjectGraphType<AllProductsInput>
    {
        public AllProductsInputType()
        {        
            Field("OrderBy", product => product.OrderBy, nullable: true);
            Field("Page", product => product.Page, nullable: true);
            Field("PageSize", product => product.PageSize, nullable: true);
        }
    }
}
