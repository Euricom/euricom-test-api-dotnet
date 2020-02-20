using System;

namespace ShopSchema
{
    public class BasketItem
    {
        public Guid Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public BasketItem(int productId, int quantity)
        {
            Id = Guid.NewGuid();
            ProductId = productId;
            Quantity = quantity;
        }
    }
}
