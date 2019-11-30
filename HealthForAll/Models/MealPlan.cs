using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthForAll.Models
{
    public class MealPlan
    {
        public IEnumerable<Meal> Meals { get; set; }
    }
}
