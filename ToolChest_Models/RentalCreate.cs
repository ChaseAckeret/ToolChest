using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolChest_Models
{
    public class RentalCreate
    {

        //the following properties will be passed in to create a new rental


        public int ToolId { get; set; }
        public int CustomerId { get; set; }
        //public int RecieptId { get; set; }
        public DateTimeOffset ScheduledStartDate { get; set; }
        public DateTimeOffset ScheduledEndDate { get; set; }

    }//end of class RentalCreate
}