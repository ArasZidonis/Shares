
using Newtonsoft.Json;

namespace Shares.Models
{
    public class Global_Quote
    {
        [JsonProperty("Global Quote")]
        public Insight globalQuote { get; set; }
    }
}
