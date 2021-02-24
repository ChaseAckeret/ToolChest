using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ToolChest_Data.Tool;

namespace ToolChest_Models
{
    public class ToolListItem
    {
        public int ToolID { get; set; }
        public decimal HourlyRate { get; set; }

        public decimal DailyRate { get; set; }

        public ConditionType ToolCondition { get; set; }

        public int ToolCatalogItem;
    }
}
