using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolChest_Models
{
    public class ToolRatingCreate
    {

        public int ToolID { get; set; }

        [Required, Range(1, 5, ErrorMessage = "Please enter at Rating of between 1 and 5.")]
        public double Condition { get; set; }

        [Required, Range(1, 5, ErrorMessage = "Please enter at Rating of between 1 and 5.")]
        public double Usability { get; set; }

        [Required, Range(1, 5, ErrorMessage = "Please enter at Rating of between 1 and 5.")]
        public double Accuracy { get; set; }
    }
}
