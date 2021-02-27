using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolChest_Data
{
    public class Owner
    {
 
        [Key, ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        //public Guid UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        [Required]
        public int OwnerId { get; set; }

        public virtual List<OwnerRating> Rating { get; set; }

        public virtual List<Tool> Tools { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset ModifiedUtc { get; set; }
    }
}
