namespace ShopSchema
{
    public class Product
    {
        public int Id { get; set; }
        public string Sku { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public string Image { get; set; }
        public bool Stocked { get; set; }
        public decimal BasePrice { get; set; }
        public decimal Price { get; set; }
        
    }
}
