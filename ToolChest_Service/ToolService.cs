﻿using System;
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
        //private readonly Guid _userId;
        private readonly String _userId;

        public ToolService(String userId)
        {
            _userId = userId;
        }
        public bool CreateTool(ToolCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                // find teh UserID that matches this entered OwnerID
                var findUserID =
                    ctx
                        .Tools
                        .Single(e => e.OwnerID == model.OwnerID);

                var entity =
                new Tool()
                {
                    UserID = findUserID.UserID,
                    OwnerID = model.OwnerID,
                    HourlyRate = model.HourlyRate,
                    DailyRate = model.DailyRate,
                    ToolCondition = model.ToolCondition,
                    ToolCatalogItemID = model.ToolCatalogItemID
                };

                ctx.Tools.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
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

        public ToolListItem GetToolByID(int toolID)
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

        public ToolFullDetail GetFullToolDetailByID(int toolID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Tools
                        .Single(e => e.ToolID == toolID);
                return
                   new ToolFullDetail
                   {
                       ToolID = entity.ToolID,
                       OwnerID = entity.Owner.OwnerId,
                       Owneremail = entity.Owner.ApplicationUser.Email,
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
                                    //HourlyRate = e.HourlyRate,
                                    //DailyRate = e.DailyRate,
                                    //ToolCondition = e.ToolCondition,
                                    //Catagory = e.ToolCatalogItem.Catagory,
                                    //ShortDescription = e.ToolCatalogItem.ShortDescription,
                                    //LongDescription = e.ToolCatalogItem.LongDescription,
                                    //Brand = e.ToolCatalogItem.Brand,
                                    //PowerSource = e.ToolCatalogItem.PowerSource,
                                    //Model = e.ToolCatalogItem.Model,
                                    //AccuracyRating = e.AccuracyRating,
                                    //UsabilityRating = e.UsabilityRating,
                                    //ConditionRating = e.ConditionRating
                                }
                        );
                foreach (ToolListItem result in query)
                {
                    returnlist.Add(GetToolByID(result.ToolID));
                }

                return returnlist;
            }
        }

    }
}
