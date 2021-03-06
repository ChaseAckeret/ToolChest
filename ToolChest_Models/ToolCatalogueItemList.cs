using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolChest_Models
{
    public class ToolCatalogueItemList
    {
        public int ToolCatalogueItemID { get; set; }
        public ToolChest_Data.ToolCatalogItem.MajorCatagory Catagory { get; set; }

        public string ShortDescription { get; set; }

        public string LongDescription { get; set; }

        public string Brand { get; set; }

        public string PowerSource { get; set; }

        public string Model { get; set; }
    }
}
