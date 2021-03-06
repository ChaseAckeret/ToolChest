using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolChest_Models
{
    public class RentalListItem
    {
        public int RentalID { get; set; }

        public string OwnerLName { get; set; }
        public string OnwerFName { get; set; }

        public string CustomerLName { get; set; }
        public string CustomerFName { get; set; }

        public int? ToolID { get; set; }

        public String ToolShortDescript { get; set; }

        public DateTimeOffset ScheduledStartDate { get; set; }
        public DateTimeOffset ScheduledEndDate { get; set; }

    }
}
