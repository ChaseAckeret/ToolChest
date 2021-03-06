using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolChest_Models
{
    public class CustomerRatingEdit
    {
        public int CustomerRatingId { get; set; }
        public int Timeliness { get; set; }
        public int Care { get; set; }
        public int Ease { get; set; }
    }
}
