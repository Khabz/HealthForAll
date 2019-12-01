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

        public bool Pregnent { get; set; }

        public bool Diebetic { get; set; }

        public HIVStatus HIVStatus { get; set; }

        public decimal FoodMonthlyExpenses { get; set; }

        public List<UserMeal> UserMeals { get; set; }

        public int Dependency { get; set; }
    }
    public enum HIVStatus
    {
        Positive,
        Negative
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
