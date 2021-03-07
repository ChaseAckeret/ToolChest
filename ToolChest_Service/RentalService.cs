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
        public IEnumerable<RentalListItem> GetRentalByToolID(int toolID)

        {
            List<RentalListItem> returnlist = new List<RentalListItem>();

            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Rentals
                        .Where(e => e.ToolId == toolID)
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

        public bool NullToolIDForRentalByToolID(int toolID)

        {
            List<RentalListItem> returnlist = new List<RentalListItem>();

            var resultquery = GetRentalByToolID(toolID);

            bool success = false;

            using (var ctx = new ApplicationDbContext())

            {
                //    var resultquery =
                //        ctx
                //            .Rentals
                //            .Where(e => e.ToolId == toolID)
                //            .Select(
                //                e =>
                //                    new RentalListItem
                //                    {
                //                        RentalID = e.RentalId,
                //                    }
                //            );
                //    resultquery.ToList();


                foreach (RentalListItem result in resultquery)
                {
                    var query =
                        ctx
                            .Rentals
                            .Single(e => e.RentalId == result.RentalID);
                    query.ToolId = null;
                    success = ctx.SaveChanges() == 1;
                }

                return success;
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

                if (entity.ToolId != null)
                {
                    return
                       new RentalListItem
                       {
                           RentalID = entity.RentalId,
                           OwnerLName = entity.Tool.Owner.LName,
                           OnwerFName = entity.Tool.Owner.FName,
                           CustomerLName = entity.CustomerID.LName,
                           CustomerFName = entity.CustomerID.FName,
                           ToolID = entity.ToolId,
                           ToolShortDescript = entity.Tool.ToolCatalogItem.ShortDescription,
                           ScheduledStartDate = entity.ScheduledStartDate,
                           ScheduledEndDate = entity.ScheduledEndDate
                       };
                }
                return
                       new RentalListItem
                       {
                           RentalID = entity.RentalId,
                           CustomerLName = entity.CustomerID.LName,
                           CustomerFName = entity.CustomerID.FName,
                           ToolID = entity.ToolId,
                           ScheduledStartDate = entity.ScheduledStartDate,
                           ScheduledEndDate = entity.ScheduledEndDate
                       };
            }
        }
    }//end of class RentalService
}
