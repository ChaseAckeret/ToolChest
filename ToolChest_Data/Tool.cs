using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolChest_Data
{
    public class Tool
    {
        public enum ConditionType { Unserviceable, Poor, Fair, Good, Excellent, New };

        [Key]
        public int ToolID { get; set; }

        //// foreign Key
        //[ForeignKey(nameof(Owner))]

        //public int OwnerID { get; set; }

        ////navigation property
        //public virtual Owner Owner { get; set; }

        [Required]
        public decimal HourlyRate { get; set; }

        public decimal DailyRate { get; set; }

        [Required]
        public ConditionType ToolCondition { get; set; }

        public int ToolCatalogItemID { get; set; }
        public ToolCatalogItem ToolCatalogItem { get; set; }

        public virtual List<ToolRating> Ratings { get; set; } = new List<ToolRating>();
        public double ConditionRating
        {
            get
            {
                double AverageConditionRating = 0;
                // sum all ratings
                foreach (var rating in Ratings)
                {
                    AverageConditionRating += rating.Condition;
                }

                // get average
                return Ratings.Count > 0 ? Math.Round(AverageConditionRating / Ratings.Count, 2) : 0;
            }
        }

        public double UsabilityRating
        {
            get
            {
                double AverageUsabilityRating = 0;
                // sum all ratings
                foreach (var rating in Ratings)
                {
                    AverageUsabilityRating += rating.Usability;
                }

                // get average
                return Ratings.Count > 0 ? Math.Round(AverageUsabilityRating / Ratings.Count, 2) : 0;
            }
        }
        public double AccuracyRating
        {
            get
            {
                double AverageAccuracyRating = 0;
                // sum all ratings
                foreach (var rating in Ratings)
                {
                    AverageAccuracyRating += rating.Accuracy;
                }

                // get average
                return Ratings.Count > 0 ? Math.Round(AverageAccuracyRating / Ratings.Count, 2) : 0;
            }
        }
    }
}
