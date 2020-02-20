using ShopSchema.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace ShopSchema
{
    public class BasketRepository : IBasket
    {
        private IProduct _product;
        public BasketRepository(IProduct product)
        {
            _product = product;
            AllBaskets = new List<Basket>();
        }

        public List<Basket> AllBaskets { get; }


        public Basket GetBasketByCheckoutId(string checkoutId)
        {
            MakeNewBasketIfBasketDoesNotExist(checkoutId);

            return AllBaskets.SingleOrDefault(basket => basket.CheckoutId == checkoutId);
        }

        public Basket AddItemToBasket(string checkoutId, int productId)
        {
            MakeNewBasketIfBasketDoesNotExist(checkoutId);

            Product product = _product.AllProducts.SingleOrDefault(prod => prod.Id == productId);

            if (product == null)
            {
                throw new ProductNotFoundException(productId);                
            }

            if (!product.Stocked)
            {
                throw new ProductIsNotStockedException(productId);
            }


            Basket basket = AllBaskets.SingleOrDefault(bas => bas.CheckoutId == checkoutId);

            BasketItem updateItemQuantity = basket.BasketItems.SingleOrDefault(basketItem => basketItem.ProductId == productId);

            if (updateItemQuantity != null)
            {
                updateItemQuantity.Quantity++;
                return basket;
            }

            basket.BasketItems.Add(new BasketItem(productId, 1));

            return basket;
        }

        public Basket ClearBasket(string checkoutId)
        {
            MakeNewBasketIfBasketDoesNotExist(checkoutId);

            Basket basketToClear = AllBaskets.SingleOrDefault(basket => basket.CheckoutId == checkoutId);

            basketToClear.BasketItems.RemoveRange(0, basketToClear.BasketItems.Count);

            return basketToClear;
        }

        public Basket RemoveItemFromBasket(string checkoutId, int productId)
        {
            MakeNewBasketIfBasketDoesNotExist(checkoutId);

            Basket basketToDeleteItemFrom = AllBaskets.SingleOrDefault(basket => basket.CheckoutId == checkoutId);

            BasketItem itemToDelete = basketToDeleteItemFrom.BasketItems.SingleOrDefault(basketItem => basketItem.ProductId == productId);

            if (itemToDelete == null)
            {
                return basketToDeleteItemFrom;
            }

            basketToDeleteItemFrom.BasketItems.Remove(itemToDelete);

            return basketToDeleteItemFrom;
        }

        private void MakeNewBasketIfBasketDoesNotExist(string checkoutId)
        {
            Basket basket = AllBaskets.SingleOrDefault(bask => bask.CheckoutId == checkoutId);

            if (basket == null)
            {
                AllBaskets.Add(new Basket(checkoutId, new List<BasketItem>()));
            }
        }
    }
}
