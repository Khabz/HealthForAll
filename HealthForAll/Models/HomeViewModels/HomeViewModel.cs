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
    }
}
