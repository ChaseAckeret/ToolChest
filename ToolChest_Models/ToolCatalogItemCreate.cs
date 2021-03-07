using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolChest_Models
{
    public class ToolCatalogItemCreate
    {
       [Required]
        /// this is an alternative to the using statc statment found in toolcreate to reference the enum?
        public ToolChest_Data.ToolCatalogItem.MajorCatagory Catagory { get; set; }

        [Required]
        [StringLength(25, ErrorMessage = "The Short Description must be at least 8 characters and no more than 25 Characters.", MinimumLength = 8)]
        public string ShortDescription { get; set; }

        [StringLength(400, ErrorMessage = "The Long Description must be at least 15 characters and no more than 200 Characters.", MinimumLength = 15)]
        public string LongDescription { get; set; }

        public string Brand { get; set; }

        public string PowerSource { get; set; }

        public string Model { get; set; }
    }
}
