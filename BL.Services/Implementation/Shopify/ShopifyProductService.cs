using System.Collections.Generic;
using BL.Objects.Shopify.Common;
using BL.Objects.Shopify.Product;

namespace BL.Services.Implementation.Shopify
{
    public class ShopifyProductService : ShopifyBaseService
    {

        public ShopifyProductService(ShopifySettings settings) : base(settings, "admin/products.json")
        {
            Settings = settings;
        }

        public ShopifyProduct GetById(long id)
        {
            return GetById<ShopifyProduct>(id);
        }

        public List<ShopifyProduct> GetByIds(List<long> ids)
        {
            return GetByIds<ShopifyProduct>(ids);
        }

        public List<ShopifyProduct> GetAll(long id = 0L)
        {
            return base.GetAll<ShopifyProduct>(id);
        }
    }
}
