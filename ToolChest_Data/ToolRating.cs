using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolChest_Data
{
    public class ToolRating
    {
        public int ToolRatingID { get; set; }

        // foreign Key
        [ForeignKey("Tool")]

        public int FKToolID { get; set; }

        //navigation property
        public virtual Tool Tool { get; set; }

        [Required, Range(1, 5)]
        public double Condition { get; set; }

        [Required, Range(1, 5)]
        public double Usability { get; set; }

        [Required, Range(1, 5)]
        public double Accuracy { get; set; }

    }
}

