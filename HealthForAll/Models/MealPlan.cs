using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthForAll.Models
{
    public class MealPlan
    {
        public string UserId { get; set; }

        public DateTime RequestedOn { get; set; }
    }
}
