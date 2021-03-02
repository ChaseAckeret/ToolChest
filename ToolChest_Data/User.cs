using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolChest_Data
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }

        // Owner Stuff
        public virtual List<OwnerRating> OwnerRatings { get; set; }

        public virtual List<Tool> Tools { get; set; }



        //public bool IsOwner { get; set; }


        public double PriceRating
        {
            get
            {
                double AveragePriceRating = 0;
                // sum all ratings
                foreach (var rating in OwnerRatings)
                {
                    AveragePriceRating += rating.Timeliness;
                }

                // get average
                return OwnerRatings.Count > 0 ? Math.Round(AveragePriceRating / OwnerRatings.Count, 2) : 0;
            }
        }
        public double AvailabilityRating
        {
            get
            {
                double AverageAvailabilityRating = 0;
                // sum all ratings
                foreach (var rating in OwnerRatings)
                {
                    AverageAvailabilityRating += rating.Availability;
                }

                // get average
                return OwnerRatings.Count > 0 ? Math.Round(AverageAvailabilityRating / OwnerRatings.Count, 2) : 0;
            }
        }

        public double TimelinessAsOwnerRating
        {
            get
            {
                double AverageTimelinessRating = 0;
                // sum all ratings
                foreach (var rating in CustomerRatings)
                {
                    AverageTimelinessRating += rating.Timeliness;
                }

                // get average
                return OwnerRatings.Count > 0 ? Math.Round(AverageTimelinessRating / OwnerRatings.Count, 2) : 0;
            }
        }

        // Rentals Stuff
        public virtual List<Rental> Rentals { get; set; }


        //  Customer Stuff

        //public bool IsCustomer { get; set; }


        public virtual List<CustomerRating> CustomerRatings { get; set; }
        public double TimelinessAsCustomerRating
        {
            get
            {
                double AverageConditionRating = 0;
                // sum all ratings
                foreach (var rating in CustomerRatings)
                {
                    AverageConditionRating += rating.Timeliness;
                }

                // get average
                return CustomerRatings.Count > 0 ? Math.Round(AverageConditionRating / CustomerRatings.Count, 2) : 0;
            }
        }
        public double CareRating
        {
            get
            {
                double AverageConditionRating = 0;
                // sum all ratings
                foreach (var rating in CustomerRatings)
                {
                    AverageConditionRating += rating.Care;
                }

                // get average
                return CustomerRatings.Count > 0 ? Math.Round(AverageConditionRating / CustomerRatings.Count, 2) : 0;
            }
        }

        public double EaseRating
        {
            get
            {
                double AverageConditionRating = 0;
                // sum all ratings
                foreach (var rating in CustomerRatings)
                {
                    AverageConditionRating += rating.Ease;
                }

                // get average
                return CustomerRatings.Count > 0 ? Math.Round(AverageConditionRating / CustomerRatings.Count, 2) : 0;
            }
        }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset ModifiedUtc { get; set; }
    }
}
