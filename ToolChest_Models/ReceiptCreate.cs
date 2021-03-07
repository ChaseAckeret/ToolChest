using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolChest_Models
{
    public class ReceiptCreate
    {
        [Required]
        public int RentalID { get; set; }

        [Required]
        public double AmountPaid { get; set; }

        [Required]
        public DateTime ActualStartDate { get; set; }

        [Required]
        public DateTime ActualEndDate { get; set; }
    }
}
