using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthForAll.Models.HomeViewModels
{
    public class HomeViewModel
    {
        [JsonProperty("current_user")]
        public UserRestModel CurrentUser { get; set; }

        [JsonProperty("new_meal")]
        public NewMealModel NewMeal { get; set; }

        [JsonProperty("is_loading")]
        public bool IsLoading { get; set; }

        [JsonProperty("is_map_showing")]
        public bool IsMapShowing { get; set; }

        public class UserRestModel {

            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("first_name")]
            public string FirstName { get; set; }

            [JsonProperty("last_name")]
            public string LastName { get; set; }

            [JsonProperty("gender")]
            public Gender Gender { get; set; }

            [JsonProperty("membership_type")]
            public MembershipType MembershipType { get; set; }
        }

        public class NewMealModel
        {
            [JsonProperty("title")]
            public string Title { get; set; }

            [JsonProperty("state")]
            public string State { get; set; }

            [JsonProperty("budget_amount")]
            public decimal BudgetAmount { get; set; }

            [JsonProperty("number_of_people")]
            public int NumberOfPeople { get; set; }

            [JsonProperty("meal_date")]
            public DateTime MealDate { get; set; }

            [JsonProperty("selected_meal")]
            public object SelectedMeal { get; set; }

            [JsonProperty("suggested_meals")]
            public List<object> SuggestedMeals { get; set; }
        }
    }
}
