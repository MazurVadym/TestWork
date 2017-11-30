using System;

namespace BL.Objects.ProductItem
{
    public class ProductItem
    {
        public Guid? Id { get; set; }

        public Guid ProductListId { get; set; } 

        public long ProductId { get; set; }

        public long VariantId { get; set; }

        public int Amount { get; set; }

        public Product.Product Product { get; set; }
    }
}
