﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolChest_Models
{
    public class OwnerRatingCreate
    {
        public int OwnerRatingId { get; set; }

        public int Price { get; set; }

        public int Availability { get; set; }

        public int Timeliness { get; set; }
    }
}
