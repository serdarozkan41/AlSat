using System;
using System.Collections.Generic;
using System.Text;
using Yeryok.Shared.Utilities;

namespace YerYok.Shared.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string CoverImg { get; set; }
        public int Price { get; set; }
        public int OldPrice { get; set; }
        public bool IsFavori { get; set; }
    }
}
