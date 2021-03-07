using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolChest_Data;
using ToolChest_Models;

namespace ToolChest_Service
{
    public class OwnerRatingService
    {
        public bool CreateOwnerRating(OwnerRatingCreate model)
        {
            var entity =
                new OwnerRating()
                {
                    FKOwnerID = model.OwnerId,
                    Price = model.Price,
                    Availability = model.Availability,
                    Timeliness = model.Timeliness
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.OwnerRatings.Add(entity);
                return ctx.SaveChanges() == 1;
            }


        }

        public bool UpdateOwnerRating(OwnerRatingCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .OwnerRatings
                        .Single(e => e.OwnerRatingId == model.OwnerId);

                entity.Timeliness = model.Timeliness;
                entity.Price = model.Price;
                entity.Availability = model.Availability;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteOwnerRating(int ownerRatingId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .OwnerRatings
                    .Single(e => e.OwnerRatingId == ownerRatingId);

                ctx.OwnerRatings.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
