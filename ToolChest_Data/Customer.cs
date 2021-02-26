using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolChest_Data
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        public virtual List<CustomerRating> Rating { get; set; }

        public virtual List<Rental> Rentals { get; set; }

        [Required]
        public Guid CustomerId { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }

        public double TimelinessRating
        {
            get
            {
                double AverageConditionRating = 0;
                // sum all ratings
                foreach (var rating in Rating)
                {
                    AverageConditionRating += rating.Timeliness;
                }

                // get average
                return Rating.Count > 0 ? Math.Round(AverageConditionRating / Rating.Count, 2) : 0;
            }
        }
        public double CareRating
        {
            get
            {
                double AverageConditionRating = 0;
                // sum all ratings
                foreach (var rating in Rating)
                {
                    AverageConditionRating += rating.Care;
                }

                // get average
                return Rating.Count > 0 ? Math.Round(AverageConditionRating / Rating.Count, 2) : 0;
            }
        }

        public double EaseRating
        {
            get
            {
                double AverageConditionRating = 0;
                // sum all ratings
                foreach (var rating in Rating)
                {
                    AverageConditionRating += rating.Ease;
                }

                // get average
                return Rating.Count > 0 ? Math.Round(AverageConditionRating / Rating.Count, 2) : 0;
            }
        }
    }
}
