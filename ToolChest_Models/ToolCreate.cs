using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ToolChest_Data.Tool;

namespace ToolChest_Models
{
    public class ToolCreate
    {

        public int OwnerID { get; set; }

        [Required]
        public decimal HourlyRate { get; set; }

        public decimal DailyRate { get; set; }

        [Required]
        public ConditionType ToolCondition { get; set; }

        public int ToolCatalogItemID { get; set; }
    }
}
