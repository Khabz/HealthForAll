using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthForAll.Models.RestModels.UserMealsRestModels
{
    /// <summary>
    /// Rest Model : Create User Meal
    /// </summary>
    public class CreateUserMealRestModel
    {
        [Required]
        [JsonProperty("user_id")]
        public string UserId { get; set; }

        [Required]
        [JsonProperty("budget_amount")]
        public decimal BudgetAmount { get; set; }

        [Required]
        [JsonProperty("meal_id")]
        public string MealId { get; set; }

        [Required]
        [JsonProperty("meal_date")]
        public DateTime MealDate { get; set; }

        [Required]
        [JsonProperty("dependents")]
        public int Dependents { get; set; }
    }
}
