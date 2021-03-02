using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolChest_Models
{
    public class CustomerList
    {
        [Display(Name = "Customer ID")]
        public int UserID { get; set; }

        [Display(Name = "First Name")]
        public string FName { get; set; }

        [Display(Name = "Last Name")]
        public string LName { get; set; }

        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "State")]
        public string State { get; set; }

        [Display(Name = "Zip")]
        public int Zip { get; set; }

        public double EaseRating { get; set; }
        public double CareRating { get; set; }
        public double TimelinessAsCustomerRating { get; set; }

        [Display(Name = "Rentals")]
        public IEnumerable<RentalListItem> Rentals { get; set; }
    }
}
