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

        //public virtual List<CustomerRating> Rating { get; set; }

        public virtual List<Rental> Rentals { get; set; }

        [Required]
        public Guid CustomerId { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
