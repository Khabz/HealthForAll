using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthForAll.Models
{
    public class MealCsvModel
    {
        public string food_name { get; set; }

        public string carbohydrate { get; set; }

        public string protein { get; set; }

        public string lipids { get; set; }

        public string fibre { get; set; }

        public string energy { get; set; }

        public string category { get; set; }

        public string price { get; set; }
    }
}
