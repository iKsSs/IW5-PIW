using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace WebApi.Models
{
    public class MovieApiModel
    {
        [JsonProperty("id")]
        public int CsfdId { get; set; }

        [JsonProperty("poster_url")]
        public string PosterUri { get; set; }
    }
}
