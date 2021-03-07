using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolChest_Data
{
    public class OwnerRating
    {
        [Key]
        public int OwnerRatingId { get; set; }

        // foreign Key
        [ForeignKey("User")]

        public int FKOwnerID { get; set; }

        //navigation property
        public virtual User User { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public int Availability { get; set; }

        [Required]
        public int Timeliness { get; set; }
    }
}
