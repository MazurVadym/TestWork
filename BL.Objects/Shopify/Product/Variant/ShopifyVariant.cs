using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Objects.Shopify.Attributes;
using BL.Objects.Shopify.Interface;
using Newtonsoft.Json;

namespace BL.Objects.Shopify.Product.Variant
{
    [ShopifyRootObject("variant")]
    public class ShopifyVariant : IShopifyBaseObject
    {
        [JsonProperty("barcode")]
        public string Barcode { get; set; }
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("price")]
        public float Price { get; set; }

        [JsonProperty("product_id")]
        public long ProductId { get; set; }

        [JsonProperty("line_items")]
        public List<ShopifyVariant> LineItems { get; set; }

        [JsonProperty("sku")]
        public string Sku { get; set; }

        [JsonProperty("grams")]
        public float Grams { get; set; }

        [JsonProperty("inventory_management")]
        public string InventoryManagement { get; set; }

        [JsonProperty("inventory_policy")]
        public string InventoryPolicy { get; set; }

        [JsonProperty("inventory_quantity")]
        public int InventoryQuantity { get; set; }

        [JsonProperty("position")]
        public int Position { get; set; }
        [JsonProperty("option1")]
        public string Option1 { get; set; }
        [JsonProperty("option2")]
        public string Option2 { get; set; }
        [JsonProperty("option3")]
        public string Option3 { get; set; }

        [JsonProperty("requires_shipping")]
        public bool RequiresShipping { get; set; }

        [JsonProperty("taxable")]
        public bool Taxable { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("weight")]
        public float Weight { get; set; }

        [JsonProperty("weight_unit")]
        public string WeightUnit { get; set; }

        [JsonProperty("fulfillment_service")]
        public string FulfillmentService { get; set; }
        [JsonProperty("image_id")]
        public long? ImageId { get; set; }
        public List<string> Images { get; set; } = new List<string>();
        //public CProduct LussoProduct { get; set; }

        public bool ShouldSerializeFulfillmentService()
        {
            return false;
        }

        public long GetLussoGeneralProductID()
        {
            if (string.IsNullOrEmpty(Sku))
                return 0;

            var st = Sku.Split('-');

            if (st.Length < 1)
                return 0;

            long l = 0;
            long.TryParse(st[0], out l);

            return l;
        }
    }

    public class MetaField
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("namespace")]
        public string NameSpace { get; set; }


        [JsonProperty("value_type")]
        public string ValueType { get; set; }
    }
}
