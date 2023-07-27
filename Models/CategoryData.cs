using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreDiscover.GenerateCategoryFeed.Models
{
    public class CategoryData
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ListOrder { get; set; }
        public bool Active { get; set; }
        public string ParentID { get; set; }
        public int ChildCount { get; set; }
        public string URLPath { get { return "/category/" + Name.ToLower().Replace(" ", string.Empty).Replace("&", "-").Replace("'", string.Empty); } }

        public string SEOName { get { return Name.Replace(" ", "-"); } }
        public object XP { get; set; }
    }
}
