using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolChest_Data;
using ToolChest_Models;

namespace ToolChest_Service
{
    public class UserService
    {
        private readonly Guid _userId;

        public UserService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateUser(UserCreate model)
        {
            var entity =
                new User()
                {
                    FName = model.FName,
                    LName = model.LName,
                    StreetAddress = model.StreetAddress,
                    City = model.City,
                    State = model.State,
                    Zip = model.Zip,
                    CreatedUtc = DateTimeOffset.Now,
                    //IsOwner = false,
                    //IsCustomer = false
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Users.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<OwnerList> GetAllOwners()
        {
            List<OwnerList> returnlist = new List<OwnerList>();

            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Users
                        .Where(e => e.Tools.Count >= 1)
                        .Select(
                            e =>
                                new UserKeyList
                                {
                                    UserID = e.UserID,
                                }
                        );

                foreach (UserKeyList results in query)
                {
                    returnlist.Add(GetOwnerDetailByID(results.UserID));
                }

                return returnlist;
            }
        }

        public IEnumerable<CustomerList> GetAllCustomers()
        {
            List<CustomerList> returnlist = new List<CustomerList>();

            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Users
                        .Where(e => e.Rentals.Count >= 1) 
                        .Select(
                            e =>
                                new UserKeyList
                                {
                                    UserID = e.UserID,
                                }
                        );

                foreach (UserKeyList results in query)
                {
                    returnlist.Add(GetCustomerDetailByID(results.UserID));
                }

                return returnlist;
            }
        }

        public OwnerList GetOwnerDetailByID(int ownerID)
        {
            ToolService toolService = new ToolService();


            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Users
                        .Single(e => e.UserID == ownerID);
                return
                   new OwnerList
                   {
                       UserID = entity.UserID,
                       FName = entity.FName,
                       LName = entity.LName,
                       StreetAddress = entity.StreetAddress,
                       City = entity.City,
                       State = entity.State,
                       Zip = entity.Zip,
                       Tools = toolService.GetToolsByOwnerID(ownerID),
                       PriceRating = entity.PriceRating,
                       AvailabilityRating = entity.AvailabilityRating,
                       TimelinessAsOwnerRating = entity.TimelinessAsOwnerRating
                   };

            }
        }

        public CustomerList GetCustomerDetailByID(int customerId)
        {
            RentalService rentalService = new RentalService();

            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Users
                        .Single(e => e.UserID == customerId);
                return
                    new CustomerList
                    {
                        UserID = entity.UserID,
                        FName = entity.FName,
                        LName = entity.LName,
                        StreetAddress = entity.StreetAddress,
                        City = entity.City,
                        State = entity.State,
                        Zip = entity.Zip,
                        Rentals = rentalService.GetRentalByCustomerID(customerId),
                        EaseRating=entity.EaseRating,
                        CareRating=entity.CareRating,
                        TimelinessAsCustomerRating=entity.TimelinessAsCustomerRating
                    };
            }
        }
    }    
}

