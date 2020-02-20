namespace ShopSchema
{
    public class AllProductsInput
    {
        public string OrderBy { get; set; }
        public int? Page { get; set; }
        public int? PageSize { get; set; }
    }
}
