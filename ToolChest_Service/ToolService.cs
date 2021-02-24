using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolChest_Data;
using ToolChest_Models;

namespace ToolChest_Service
{
    public class ToolService
    {
        public bool CreateTool(ToolCreate model)
        {
            var entity =
                new Tool()
                {

                    HourlyRate = model.HourlyRate,
                    DailyRate = model.DailyRate,
                    ToolCondition = model.ToolCondition,
                    ToolCatalogItemID = model.ToolCatalogItemID
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Tools.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public bool CreateToolRating(ToolRatingCreate model)
        {
            var entity =
                new ToolRating()
                {

                    ToolID = model.ToolID,
                    Accuracy = model.Accuracy,
                    Condition = model.Condition,
                    Usability = model.Usability
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.ToolRatings.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public bool CreateCatalogItem(ToolCatalogItemCreate model)
        {
            var entity =
                new ToolCatalogItem()
                {

                    Catagory = model.Catagory,
                    ShortDescription = model.ShortDescription,
                    LongDescription = model.LongDescription,
                    Brand = model.Brand,
                    PowerSource = model.PowerSource,
                    Model = model.Model
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.ToolCatalogItems.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

    }
}
