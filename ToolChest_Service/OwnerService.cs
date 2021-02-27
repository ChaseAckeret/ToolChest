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
                        .Owners
                        .Where(e => e.OwnerId > 0)
                        .Select(
                            e =>
                                new OwnerList
                                {
                                    OwnerID = e.OwnerId,
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


        public bool CreateOwner(OwnerCreate model)
        {
            var entity =
                 new Owner()
                 {
                     UserId = _userId,
                     OwnerId = FindNextOwnerID(),
                     CreatedUtc = DateTimeOffset.Now
                 };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Owners.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<OwnerListItem> GetOwners()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Owners
                        .Where(e => e.UserId == _userId)
                        .Select(
                            e =>
                                new OwnerListItem
                                {
                                    OwnerId = e.OwnerId,
                                    CreatedUtc = e.CreatedUtc

                                }
                        );

                return query.ToArray();
            }
        }
    }
}
