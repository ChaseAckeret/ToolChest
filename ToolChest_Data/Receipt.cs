using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolChest_Data
{
    public class Receipt
    {

        // foreign Key
        [Key, ForeignKey("Rental")]

        public int FKRentalID { get; set; }

        //navigation property
        public virtual Rental Rental { get; set; }

        [Required]
        public double AmountPaid { get; set; }

        [Required]
        public DateTime ActualStartDate { get; set; }

        [Required]
        public DateTime ActualEndDate { get; set; }
    }
}
