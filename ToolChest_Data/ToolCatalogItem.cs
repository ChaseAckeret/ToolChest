using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolChest_Data
{
    public class ToolCatalogItem
    {

        public enum  MajorCatagory 
        {
            Woodworking = 1,
            LawnandGarden,
            LargeEquipment,
            Construction,
            Demolition,
            Cleaning,
            Painting,
            Generation
         }

        [Key]
        public int ToolCatalogItemID { get; set; }

        [Required]
        public MajorCatagory Catagory { get; set; }

        [Required]
        public string ShortDescription { get; set; }

        public string LongDescription { get; set; }

        public string Brand { get; set; }

        public string PowerSource { get; set; }

        public string Model { get; set; }

        public virtual List<Tool> ToolsOfType { get; set; } = new List<Tool>();
    }
}
