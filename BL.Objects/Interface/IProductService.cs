using System.Collections.Generic;
using BL.Objects.Shopify.Product;

namespace BL.Objects.Interface
{
    public interface IProductService
    {
        List<Product.Product> GetAll();
        List<Product.Product> GetByIds(List<long> ids);
        Product.Product ToProduct(ShopifyProduct shopifyProduct);
        List<Product.Product> ToProduct(List<ShopifyProduct> shopifyProducts);
    }
}