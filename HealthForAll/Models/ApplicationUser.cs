using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthForAll.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Gender Gender { get; set; }

        public MembershipType MembershipType { get; set; }
    }
    public enum Gender
    {
        Female,
        Male
    }
    public enum MembershipType
    {
        Patient,
        Dietian,
        Nurse
    }
}
