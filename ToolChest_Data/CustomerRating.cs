using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolChest_Data
{
    public class CustomerRating
    {
        [Key]
        public int CustomerRatingId { get; set; }

        // foreign Key
        [ForeignKey("User")]

        public int FKCustomerID { get; set; }

        //navigation property
        public virtual User User { get; set; }

        [Required]
        public int Timeliness { get; set; }

        [Required]
        public int Care { get; set; }

        [Required]
        public int Ease { get; set; }
    }
}
