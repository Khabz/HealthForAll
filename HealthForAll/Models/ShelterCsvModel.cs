using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthForAll.Models
{
    public class ShelterCsvModel
    {
        public string name { get; set; }
        public string classification { get; set; }
        public string province { get; set; }
        public string longitude { get; set; }
        public string latitude { get; set; }
        public string area_type { get; set; }
        public string ownership { get; set; }
        public string district { get; set; }
        public string sub_district { get; set; }
        public string postal_area { get; set; }
        public string postal_address { get; set; }
        public string street_address { get; set; }
    }
}
