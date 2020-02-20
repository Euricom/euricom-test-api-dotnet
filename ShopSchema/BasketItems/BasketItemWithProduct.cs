using System;

namespace ShopSchema
{
    public class BasketItemWithProduct
    {
        public Guid Id { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public BasketItemWithProduct(Guid id, Product product, int quantity)
        {
            Id = id;
            Product = product;
            Quantity = quantity;
        }
    }
}