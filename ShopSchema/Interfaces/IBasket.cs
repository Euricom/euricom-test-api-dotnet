using System.Collections.Generic;

namespace ShopSchema
{
    public interface IBasket
    {
        List<Basket> AllBaskets { get; }

        Basket GetBasketByCheckoutId(string checkoutId);

        Basket AddItemToBasket(string checkoutId, int productId);

        Basket RemoveItemFromBasket(string checkoutId, int productId);

        Basket ClearBasket(string checkoutId);
    }
}
