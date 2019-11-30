using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthForAll.Models
{
    public class Shelter
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Classification { get; set; }

        public string Province { get; set; }

        public decimal Longitude { get; set; }

        public decimal Latitude { get; set; }

        [Display(Name = "Area Type")]
        public AreaType AreaType { get; set; }

        public string Ownership { get; set; }

        public string District { get; set; }

        [Display(Name = "Sub District")]
        public string SubDistrict { get; set; }

        [Display(Name = "Postal Address")]
        public string PostalAddress { get; set; }

        [Display(Name = "Postal Street")]
        public string PostalStreet { get; set; }

        [Display(Name = "Postal Area")]
        public string PostalArea { get; set; }
    }
    public enum AreaType
    {
        Rural,
        Urban
    }
}
