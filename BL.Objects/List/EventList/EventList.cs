using System;
using System.Collections.Generic;

namespace BL.Objects.List.EventList
{
    public class EventList : BaseList
    {
        public string Title { get; set; }

        public long Public { get; set; }

        public string Description { get; set; }

        public List<ProductList.ProductList> ProductList { get; set; }
    }
}
