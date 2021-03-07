using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolChest_Models
{
    public class ReceiptEdit
    {
        [Required]
        public int ReceiptID { get; set; }
        [Required]

        public double AmountPaid { get; set; }

        [Required]
        public DateTime ActualStartDate { get; set; }

        [Required]
        public DateTime ActualEndDate { get; set; }
    }
}
