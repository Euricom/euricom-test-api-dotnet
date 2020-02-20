using System.Collections.Generic;

namespace ShopSchema
{
    public interface IProduct
    {
        List<Product> AllProducts { get; }

        List<Product> GetAllProducts(string orderBy, int? page, int? pageSize);

        Product GetProductById(int id);

        Product AddProduct(Product product);

        List<Product> DeleteProductById(int id);
    }
}
