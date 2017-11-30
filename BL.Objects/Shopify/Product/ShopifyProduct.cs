using System;
using System.Collections.Generic;
using System.Linq;
using BL.Objects.Shopify.Attributes;
using BL.Objects.Shopify.Interface;
using BL.Objects.Shopify.Product.Variant;
using Newtonsoft.Json;

namespace BL.Objects.Shopify.Product
{
    public class ShopifyOption
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
    /// <summary>
    /// Class ShopifyProduct.
    /// </summary>
    [ShopifyRootObject("product")]
    public class ShopifyProduct : IShopifyBaseObject, IItem
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("handle")]
        public string Handle { get; set; }

        [JsonProperty("variants")]
        public List<ShopifyVariant> Variants { get; set; }

        [JsonProperty("options")]
        public List<ShopifyOption> Options { get; set; }

        [JsonProperty("vendor")]
        public string Vendor { get; set; }

        [JsonProperty("product_type")]
        public string ProductType { get; set; }
        [JsonProperty("published_at")]
        public DateTime? PublishedAt { get; set; }

        [JsonProperty("body_html")]
        public string Body { get; set; }

        [JsonProperty("images")]
        public List<ShopifyImage> Images { get; set; }

        [JsonProperty("tags")]
        public string Tags
        {
            set
            {
                _tags = new HashSet<string>();

                if (string.IsNullOrEmpty(value))
                    return;

                foreach (var sp in value.Split(','))
                    _tags.Add(sp.Trim());
            }
            get => string.Join(",", _tags);
        }

        public bool AddTag(string tag)
        {
            return _tags.Add(tag);
        }

        public List<string> GetTags()
        {
            return _tags.ToList();
        }

        private HashSet<string> _tags = new HashSet<string>();

        [JsonProperty("published_scope")]
        public string PublishedScope { get; set; } = "";

        [JsonProperty("metafields_global_title_tag")]
        public string MetafieldsGlobalTitleTag { get; set; }
        [JsonProperty("metafields_global_description_tag")]
        public string MetafieldsGlobalDescriptionTag { get; set; }
    }

    [ShopifyRootObject("image")]
    public class ShopifyImage : IShopifyBaseObject
    {
        [JsonProperty("src")]
        public string Src { get; set; }

        [JsonProperty("product_id")]
        public long ProductId { get; set; }

        [JsonProperty("variant_ids")]
        public List<long> Variants { get; set; }
        [JsonProperty("position")]
        public int Position { get; set; }
        public ShopifyImage(string url)
        {
            Src = url;
        }

        public long Id { get; set; }
    }

    public class Item
    {

        [JsonProperty("product_id")]
        public string ProductId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }

        [JsonProperty("list_price")]
        public string ListPrice { get; set; }

        [JsonProperty("quantity")]
        public string Quantity { get; set; }

        [JsonProperty("product_code")]
        public string ProductCode { get; set; }

        [JsonProperty("image_link")]
        public string ImageLink { get; set; }

        [JsonProperty("add_to_cart_id")]
        public string AddToCartId { get; set; }
    }

    public class Example
    {

        [JsonProperty("totalItems")]
        public int TotalItems { get; set; }

        [JsonProperty("startIndex")]
        public int StartIndex { get; set; }

        [JsonProperty("itemsPerPage")]
        public int ItemsPerPage { get; set; }

        [JsonProperty("currentItemCount")]
        public int CurrentItemCount { get; set; }

        [JsonProperty("suggestions")]
        public IList<string> Suggestions { get; set; }

        [JsonProperty("items")]
        public IList<Item> Items { get; set; }
    }
}
