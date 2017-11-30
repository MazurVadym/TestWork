using System;
using System.Collections.Generic;

namespace BL.Objects.List.ProductList
{
    public class ProductList : BaseList
    {
        public Guid? EventListId { get; set; }

        public List<ProductItem.ProductItem> ProductItem { get; set; }
    }
}
