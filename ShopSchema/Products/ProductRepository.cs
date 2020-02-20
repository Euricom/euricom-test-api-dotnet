using ShopSchema.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace ShopSchema
{
    public class ProductRepository : IProduct
    {
        public ProductRepository()
        {
            AllProducts = new List<Product>();
            AllProducts.Add(new Product
            {
                Id = 0,
                Sku = "Fubar",
                Title = "Rias Gremory",
                Desc = "A high class devil.",
                Image = "Rias",
                Stocked = true,
                BasePrice = 6.66M,
                Price = 6.66M
            }); 
        }

        public List<Product> AllProducts { get; }

        public List<Product> GetAllProducts(string orderBy, int? page, int? pageSize)
        {
            List<Product> products = new List<Product>();
            if (orderBy == null)
            {
                products = AllProducts;
            }
            else
            {
                orderBy = char.ToUpper(orderBy[0]) + orderBy.Substring(1).ToLower();

                try
                {
                    IEnumerable<Product> sortedProducts = AllProducts.OrderBy(prod => prod.GetType().GetProperty(orderBy).GetValue(prod));
                    products.AddRange(sortedProducts.Select(product => product));
                }
                catch
                {
                    throw new PropertyNotFoundException(orderBy);                    
                }
            }

            if (page != null && pageSize != null && 0 < page && 0 < pageSize)
            {
                int pageCalculated = ((int)page - 1) * (int)pageSize;
                int totalNumberOfProducts = products.Count;
                int totalNumberOfASkedProducts = (int)page * (int)pageSize;
                double totalNumberOfPages = totalNumberOfProducts / (double)pageSize;

                if (totalNumberOfPages + 1 <= page)
                {
                    throw new PageOutOfRangeException((int)page);                    
                }

                if (totalNumberOfProducts <= totalNumberOfASkedProducts)
                {
                    int numberOfPorductsToGet = totalNumberOfProducts - pageCalculated;
                    return products.GetRange(pageCalculated, numberOfPorductsToGet);
                }

                return products.GetRange(pageCalculated, (int)pageSize);
            }

            return products;
        }
        public Product GetProductById(int id)
        {
            Product product = AllProducts.SingleOrDefault(prod => prod.Id == id);

            if(product == null)
            {
                throw new ProductNotFoundException(id);
            }

            return product;
        }

        public Product AddProduct(Product product)
        {
            foreach (Product prod in AllProducts)
            {
                if (prod.Id == product.Id)
                {
                    prod.Sku = product.Sku;
                    prod.Title = product.Title;
                    prod.Desc = product.Desc;
                    prod.Image = product.Image;
                    prod.Stocked = product.Stocked;
                    prod.BasePrice = product.BasePrice;
                    prod.Price = product.Price;

                    return product;
                }
            }

            AllProducts.Add(product);

            return product;
        }

        public List<Product> DeleteProductById(int id)
        {
            Product productToDelete = AllProducts.SingleOrDefault(product => product.Id == id);

            if (productToDelete == null)
            {
                return AllProducts;
            }

            AllProducts.Remove(productToDelete);

            return AllProducts;
        }
    }
}
