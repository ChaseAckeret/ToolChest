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
        public int Id { get; set; }

        public virtual List<OwnerRating> Rating { get; set; }

        public virtual List<Tool> Tools { get; set; }

        [Required]
        public Guid OwnerId { get; set; }
    }
}
