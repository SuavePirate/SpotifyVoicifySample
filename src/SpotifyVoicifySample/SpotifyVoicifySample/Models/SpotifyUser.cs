using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpotifyVoicifySample.Models
{
    public class SpotifyUser
    {
        [JsonProperty("display_name")]
        public string DisplayName { get; set; }
        public string Email { get; set; }
    }
}
