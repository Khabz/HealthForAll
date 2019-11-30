using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthForAll.Models
{
    public class Meal
    {
        public string Id { get; set; }

        public string FoodName { get; set; }

        public string Carbohydrate { get; set; }

        public string Liqids { get; set; }

        public string Protein { get; set; }

        public string Fibre { get; set; }

        public string Energy { get; set; }

        public string Category { get; set; }

        public decimal Price { get; set; }
    }
}
