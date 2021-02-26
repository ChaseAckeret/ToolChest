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
        private readonly Guid _userId;

        public OwnerService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateOwner(OwnerCreate model)
        {
            var entity =
                 new Owner()
                 {
                     UserId = _userId,
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
