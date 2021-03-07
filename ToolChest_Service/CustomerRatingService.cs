using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolChest_Data;
using ToolChest_Models;

namespace ToolChest_Service
{
    public class CustomerRatingService
    {
        public bool CreateCustomerRating(CustomerRatingCreate model)
        {
            var entity =
                new CustomerRating()
                {
                    CustomerRatingId = model.CustomerRatingId,
                    Timeliness = model.Timeliness,
                    Care = model.Care,
                    Ease = model.Ease
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.CustomerRatings.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public bool UpdateCustomerRating(CustomerRatingCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .CustomerRatings
                        .Single(e => e.CustomerRatingId == model.CustomerRatingId);

                entity.Timeliness = model.Timeliness;
                entity.Care = model.Care;
                entity.Ease = model.Ease;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCustomerRating(int customerRatingId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .CustomerRatings
                        .Single(e => e.CustomerRatingId == customerRatingId);

                ctx.CustomerRatings.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
