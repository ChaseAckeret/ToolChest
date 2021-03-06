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

        public ToolService()
        {
        }

        // 
        // Tool methods
        //

        public bool CreateTool(ToolCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {

                var entity =
                new Tool()
                {
                    OwnerID = model.OwnerID,
                    HourlyRate = model.HourlyRate,
                    DailyRate = model.DailyRate,
                    ToolCondition = model.ToolCondition,
                    ToolCatalogItemID = model.ToolCatalogItemID,

                };

                //entity.Owner.IsOwner = true;
                ctx.Tools.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public ToolListItem GetSingleToolByID(int toolID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Tools
                        .Single(e => e.ToolID == toolID);
                return
                   new ToolListItem
                   {
                       ToolID = entity.ToolID,
                       HourlyRate = entity.HourlyRate,
                       DailyRate = entity.DailyRate,
                       ToolCondition = entity.ToolCondition,
                       Catagory = entity.ToolCatalogItem.Catagory,
                       ShortDescription = entity.ToolCatalogItem.ShortDescription,
                       LongDescription = entity.ToolCatalogItem.LongDescription,
                       Brand = entity.ToolCatalogItem.Brand,
                       PowerSource = entity.ToolCatalogItem.PowerSource,
                       Model = entity.ToolCatalogItem.Model,
                       AccuracyRating = entity.AccuracyRating,
                       UsabilityRating = entity.UsabilityRating,
                       ConditionRating = entity.ConditionRating
                   };

            }
        }
        public bool EditToolItem(int toolEditId, ToolEdit toolEdit)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Tools
                        .Single(e => e.ToolID == toolEditId);

                entity.DailyRate = toolEdit.DailyRate;
                entity.HourlyRate = toolEdit.HourlyRate;
                entity.ToolCondition = toolEdit.ToolCondition;

                bool returnbool = false;
                int result = ctx.SaveChanges();
                if (result == 1) returnbool = true;
                return returnbool;

            }
        }
        public bool DeleteTool(int toolId)
        {
            var rentalservice = new RentalService();

            // null add th etoolID's for any rentals with this tool ID

            rentalservice.NullToolIDForRentalByToolID(toolId);

            // now remove those tool rows

            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Tools.Single(e => e.ToolID == toolId);

                ctx.Tools.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<ToolListItem> GetAllTools()

        {
            List<ToolListItem> returnlist = new List<ToolListItem>();

            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Tools
                        .Where(e => e.ToolID > 0)
                        .Select(
                            e =>
                                new ToolListItem
                                {
                                    ToolID = e.ToolID,

                                }
                        );
                foreach (ToolListItem result in query)
                {
                    returnlist.Add(GetSingleToolByID(result.ToolID));
                }

                return returnlist;
            }
        }
        public IEnumerable<ToolListItem> GetToolsByOwnerID(int ownerID)

        {
            List<ToolListItem> returnlist = new List<ToolListItem>();

            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Tools
                        .Where(e => e.OwnerID == ownerID)
                        .Select(
                            e =>
                                new ToolListItem
                                {
                                    ToolID = e.ToolID,

                                }
                        );
                foreach (ToolListItem result in query)
                {
                    returnlist.Add(GetSingleToolByID(result.ToolID));
                }

                return returnlist;
            }
        }

        //
        // Tool Rating Methods
        //

        public bool CreateToolRating(ToolRatingCreate model)
        {
            var entity =
                new ToolRating()
                {

                    FKToolID = model.ToolID,
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
        public bool DeleteToolRating(int toolRatingId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.ToolRatings.Single(e => e.ToolRatingID == toolRatingId);

                ctx.ToolRatings.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
        public ToolDetails GetFullToolDetailByID(int toolID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Tools
                        .Single(e => e.ToolID == toolID);
                return
                   new ToolDetails
                   {
                       ToolID = entity.ToolID,
                       OwnerID = entity.Owner.UserID,
                       Name = entity.Owner.FName + " " + entity.Owner.LName,
                       HourlyRate = entity.HourlyRate,
                       DailyRate = entity.DailyRate,
                       ToolCondition = entity.ToolCondition,
                       Catagory = entity.ToolCatalogItem.Catagory,
                       ShortDescription = entity.ToolCatalogItem.ShortDescription,
                       LongDescription = entity.ToolCatalogItem.LongDescription,
                       Brand = entity.ToolCatalogItem.Brand,
                       PowerSource = entity.ToolCatalogItem.PowerSource,
                       Model = entity.ToolCatalogItem.Model,
                       AccuracyRating = entity.AccuracyRating,
                       UsabilityRating = entity.UsabilityRating,
                       ConditionRating = entity.ConditionRating
                   };

            }
        }

        //
        // Tool Catalogue Methods
        //

        public bool EditCatalogItem(int toolCatalogueItemId, ToolCatalogItemCreate toolCatalogItem)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .ToolCatalogItems
                        .Single(e => e.ToolCatalogItemID == toolCatalogueItemId);

                if (toolCatalogItem.LongDescription != null)
                    entity.LongDescription = toolCatalogItem.LongDescription;
                if (toolCatalogItem.Brand != null)
                    entity.Brand = toolCatalogItem.Brand;
                if (toolCatalogItem.PowerSource != null)
                    entity.PowerSource = toolCatalogItem.PowerSource;
                if (toolCatalogItem.Model != null)
                    entity.Model = toolCatalogItem.Model;

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

        public ToolCatalogueItemList GetSingleToolCatalogueItemByID(int toolCatalogueItemID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .ToolCatalogItems
                        .Single(e => e.ToolCatalogItemID == toolCatalogueItemID);
                return
                   new ToolCatalogueItemList
                   {
                       ToolCatalogueItemID = entity.ToolCatalogItemID,
                       Catagory = entity.Catagory,
                       ShortDescription = entity.ShortDescription,
                       LongDescription = entity.LongDescription,
                       Brand = entity.Brand,
                       PowerSource = entity.PowerSource,
                       Model = entity.Model
                   };

            }
        }
        public IEnumerable<ToolCatalogueItemList> GetAllToolCatalogueItems()

        {
            List<ToolCatalogueItemList> returnList = new List<ToolCatalogueItemList>();

            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .ToolCatalogItems
                        .Where(e => e.ToolCatalogItemID > 0)
                        .Select(
                            e =>
                                new ToolCatalogueItemList
                                {
                                    ToolCatalogueItemID = e.ToolCatalogItemID
                                }
                        );
                foreach (ToolCatalogueItemList result in query)
                {
                    returnList.Add(GetSingleToolCatalogueItemByID(result.ToolCatalogueItemID));
                }

                return returnList;
            }
        }
    }
}

