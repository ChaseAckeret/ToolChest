using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolChest_Data;
using ToolChest_Models;

namespace ToolChest_Service
{
    public class OwnerService
    {
        //private readonly Guid _userId;
        private readonly String _userId;

        public OwnerService(String userId)
        {
            _userId = userId;
        }
        public int FindNextOwnerID()
        {
            // Method finds the highest OwnerId and returns it + 1. Makes a unique OwnerID int

            //List<Owner> returnlist = new List<Owner>();

            int NextOwnerID = 1;

            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Users
                        .Where(e => e.UserID > 0)
                        .Select(
                            e =>
                                new OwnerList
                                {
                                    OwnerID = e.UserID,
                                }
                        );
                foreach (OwnerList result in query)
                {
                    if (result.OwnerID > NextOwnerID)
                    {
                        NextOwnerID = result.OwnerID;
                    }
                }

                return NextOwnerID++;
            } // end FindNextOwnerID
        }


        public bool CreateOwner(UserCreate model)
        {
            var entity =
                 new User()
                 {
                     UserID = FindNextOwnerID(),
                     FName = model.FName,
                     LName = model.LName,
                     StreetAddress = model.StreetAddress,
                     City = model.City,
                     State = model.State,
                     Zip = model.Zip,
                     CreatedUtc = DateTimeOffset.Now
                 };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Users.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        //public IEnumerable<OwnerListItem> GetUsers()
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var query =
        //            ctx
        //                .Users
        //                .Where(e => e.IsOwner == true)
        //                .Select(
        //                    e =>
        //                        new OwnerListItem
        //                        {
        //                            OwnerId = e.OwnerId,
        //                            CreatedUtc = e.CreatedUtc

        //                        }
        //                );

        //        return query.ToArray();
        //    }
        //}
    }
}
