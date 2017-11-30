using Newtonsoft.Json;

namespace BL.Objects.Shopify.Interface
{
    public interface IShopifyBaseObject
    {
        [JsonProperty("id")]
        long Id { get; set; }
    }
}