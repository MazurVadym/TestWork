using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Objects.Shopify.Attributes
{
    public class ShopifyRootObject : Attribute
    {
        public string Name { get; set; }

        public ShopifyRootObject(string name)
        {
            Name = name;
        }
    }
}
