using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolChest_Models
{
    public class CustomerCreate
    {
        [Required]
        public bool CustomerEUA { get; set; }
    }
}
