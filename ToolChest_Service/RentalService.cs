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

        public IEnumerable<RentalListItem> GetRentalByCustomerID(int customerID)

        {
            List<RentalListItem> returnlist = new List<RentalListItem>();

            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Rentals
                        .Where(e => e.CustomerId == customerID)
                        .Select(
                            e =>
                                new RentalListItem
                                {
                                    RentalID = e.RentalId,
                                }
                        );
                foreach (RentalListItem result in query)
                {
                    returnlist.Add(GetSingleRentalByID(result.RentalID));
                }

                return returnlist;
            }
        }

        public IEnumerable<RentalListItem> GetRentalByUserID(int userID)

        {
            List<RentalListItem> returnlist = new List<RentalListItem>();

            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Rentals
                        .Where(e => e.CustomerId == userID || e.Tool.OwnerID == userID)
                        .Select(
                            e =>
                                new RentalListItem
                                {
                                    RentalID = e.RentalId,
                                }
                        );
                foreach (RentalListItem result in query)
                {
                    returnlist.Add(GetSingleRentalByID(result.RentalID));
                }

                return returnlist;
            }
        }

        public RentalListItem GetSingleRentalByID(int rentalID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Rentals
                        .Single(e => e.RentalId == rentalID);
                return
                   new RentalListItem
                   {
                       RentalID = entity.RentalId,
                       OwnerLName = entity.Tool.Owner.LName,
                       OnwerFName = entity.Tool.Owner.FName,
                       CustomerLName = entity.CustomerID.LName,
                       CustomerFName = entity.CustomerID.FName,
                       ToolShortDescript = entity.Tool.ToolCatalogItem.ShortDescription,
                       ScheduledStartDate = entity.ScheduledStartDate,
                       ScheduledEndDate = entity.ScheduledEndDate
                   };

            }
        }

        public IEnumerable<RentalListItem> GetAllRentals()
        {
            List<RentalListItem> returnList = new List<RentalListItem>();

            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Rentals
                        .Where(e => e.RentalId > 0)
                        .Select(
                            e =>
                                new RentalListItem
                                {

                                    RentalID = e.RentalId,

                                }//end of new RentalListItem


                        );//end of select
                foreach (RentalListItem result in query)
                {

                    returnList.Add(GetSingleRentalByID(result.RentalID));

                }//end of foreach rentalListItem in query

                return returnList;

            }//end of using



        }//end of method GetAllRentals


        //now to create a delete method to remove a rental from the rentals table

        public bool DeleteRental(int rentalId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Rentals.Single(e => e.RentalId == rentalId);
                ctx.Rentals.Remove(entity);
                return ctx.SaveChanges() == 1;

            }//end of using


        }//end of method DeleteRental




    }//end of class RentalService
}
