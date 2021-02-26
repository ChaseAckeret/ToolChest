using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolChest_Data
{
    public class CustomerRating
    {
        [Key]
        public int CustomerRatingId { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        public int Timeliness { get; set; }

        [Required]
        public int Care { get; set; }

        [Required]
        public int Ease { get; set; }
    }
}
