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
        }
    }
}
