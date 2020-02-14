using System;
using System.Collections.Generic;
using System.Text;
using Yeryok.Shared.Utilities;
using YerYok.Shared.Enums;

namespace YerYok.Shared.Entities
{
    public class Menu : BaseEntity
    {
        public string Icon { get; set; }
        public string CategoryName { get; set; }
        public MenuStatus MenuStatus { get; set; }
    }
}
