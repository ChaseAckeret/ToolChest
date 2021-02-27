using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolChest_Data;
using static ToolChest_Data.Tool;

namespace ToolChest_Models
{
    public class ToolFullDetail
    {
        // add display labels to these
        //[Display(Name = "Created")]

        public int ToolID { get; set; }

        [Display(Name = "OwnerID")]
        public int OwnerID { get; set; }

        [Display(Name = "Owner email")]
        public string Owneremail { get; set; }

        public decimal HourlyRate { get; set; }

        public decimal DailyRate { get; set; }

        public ConditionType ToolCondition { get; set; }

        public ToolChest_Data.ToolCatalogItem.MajorCatagory Catagory { get; set; }

        public string ShortDescription { get; set; }

        public string LongDescription { get; set; }

        public string Brand { get; set; }

        public string PowerSource { get; set; }

        public string Model { get; set; }

        public double ConditionRating { get; set; }

        public double UsabilityRating { get; set; }

        public double AccuracyRating { get; set; }

    }
}
