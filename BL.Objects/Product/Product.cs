using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Objects.Product
{
    public class Product
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public string ImgUrl { get; set; }

        public List<Variant> Variants { get; set; } = new List<Variant>();
    }

    public class Variant
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public List<string> ImgUrl { get; set; } = new List<string>();

        public float Price { get; set; }
    }
}
