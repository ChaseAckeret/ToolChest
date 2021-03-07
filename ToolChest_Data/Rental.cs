using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolChest_Data
{
    public class Rental
    {
        [Key]
        public int RentalId { get; set; }

        [ForeignKey("Tool")]
        public int? ToolId { get; set; }
        public virtual Tool Tool { get; set; }


        //[ForeignKey("OwnerID")]
        //public int OwnerId { get; set; }
        //public virtual User OwnerID { get; set; }

        [ForeignKey("CustomerID")]
        public int CustomerId { get; set; }
        public virtual User CustomerID { get; set; }
        //The above should be:         public virtual User Customer { get; set; }


        [ForeignKey("Receipt")]
        public int RecieptId { get; set; }
        // now our virtual box to store the receipt
        public virtual Receipt Receipt { get; set; }


        public DateTimeOffset ScheduledStartDate { get; set; }
        public DateTimeOffset ScheduledEndDate { get; set; }


    }//end of class Rental
}
