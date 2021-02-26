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
    }
}
