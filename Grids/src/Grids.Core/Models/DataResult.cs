using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Grids.Core.Models
{
    public class DataResult
    {
        [JsonProperty("data")]
        public JToken[] Data { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }
    }
}
