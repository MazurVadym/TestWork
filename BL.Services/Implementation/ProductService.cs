using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Objects.Comman;
using BL.Objects.Interface;
using BL.Objects.Product;
using BL.Objects.Shopify.Common;
using BL.Objects.Shopify.Product;
using BL.Services.Implementation.Shopify;
namespace BL.Services.Implementation
{
    public class ProductService : IProductService
    {
        private readonly ShopifyProductService _shopifyProductService = new ShopifyProductService(new ShopifySettings(SystemSettings.StoreHost, SystemSettings.AccessToken));

        public List<Product> GetAll()
        {
            var shopifyProducts = _shopifyProductService.GetAll();

            return ToProduct(shopifyProducts);
        }

        public List<Product> GetByIds(List<long> ids)
        {
            var shopifyProducts = _shopifyProductService.GetByIds(ids);

            return ToProduct(shopifyProducts);
        }

        public Product ToProduct(ShopifyProduct shopifyProduct)
        {
            var product = new Product
            {
                Id = shopifyProduct.Id,
                Title = shopifyProduct.Title,
                ImgUrl = shopifyProduct.Images.FirstOrDefault(x => x.Variants.Count == 0)?.Src
            };

            if (string.IsNullOrEmpty(product.ImgUrl))
                product.ImgUrl = shopifyProduct.Images.FirstOrDefault()?.Src;

            foreach (var shopifyVariant in shopifyProduct.Variants)
            {
                var variant = new Variant
                {
                    Id = shopifyVariant.Id,
                    Title = shopifyVariant.Title,
                    Price = shopifyVariant.Price,
                    ImgUrl = shopifyProduct.Images.Where(x => x.Variants.Any(y => y == shopifyVariant.Id))
                        .Select(x => x.Src).ToList()
                };

                product.Variants.Add(variant);
            }

            return product;
        }

        public List<Product> ToProduct(List<ShopifyProduct> shopifyProducts)
        {
            return shopifyProducts.Select(ToProduct).ToList();
        }
    }
}
