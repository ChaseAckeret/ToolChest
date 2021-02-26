using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolChest_Data;
using ToolChest_Models;

namespace ToolChest_Service
{
    public class RentalService
    {


        //method to create a rental by passing in the required information
        public bool CreateRental(RentalCreate model)
        {
            var entity =
                new Rental()
                {
                    ToolId = model.ToolId,

                    CustomerId = model.CustomerId,

                    ScheduledStartDate = model.ScheduledStartDate,

                    ScheduledEndDate = model.ScheduledEndDate

                };//end of defining attributes for new Rental

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Rentals.Add(entity);
                return ctx.SaveChanges() == 1;
            }//end of using

        }//end of method CreateRental



    }//end of class RentalService
}
