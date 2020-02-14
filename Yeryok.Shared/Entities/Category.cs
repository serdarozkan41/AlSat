using System;
using System.Collections.Generic;
using System.Text;
using Yeryok.Shared.Utilities;

namespace YerYok.Shared.Entities
{
    public class Category : BaseEntity
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public bool IsType { get; set; }
    }
}
