using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolChest_Data
{
    public class Receipt
    {
        //our receipt is a one to one with Rental
        //so we use a foreign key here to indicate a one to one for our entity framework
        //we don't have a rental Id because our receipt id is actually the rental 
        [ForeignKey("Rental")]
        public int ReceiptId { get; set; }
        public virtual Rental Rental { get; set; }
        public double AmountPaid { get; set; }
        public DateTimeOffset ActualStartDate { get; set; }
        public DateTimeOffset ActualEndDate { get; set; }

    }//end of class Receipt
}
