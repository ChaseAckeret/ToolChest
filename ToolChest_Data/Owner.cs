using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolChest_Data
{
    public class Owner
    {
        [Key]
        public int OwnerId { get; set; }

        public virtual List<OwnerRating> Rating { get; set; }

        public virtual List<Tool> Tools { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset ModifiedUtc { get; set; }
    }
}
