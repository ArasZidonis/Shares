using Newtonsoft.Json;
using Shares.Models;

namespace Shares.Models

{
    public class Insight
    {
        //public string GlobalQuote { get; set; }
        [JsonProperty("01. symbol")]
        public string symbol { get; set; }

        [JsonProperty("02. open")]
        public double open { get; set; }

        [JsonProperty("03. high")]
        public double high { get; set; }

        [JsonProperty("04. low")]
        public double low { get; set; }

        [JsonProperty("05. price")]
        public double price { get; set; }
        [JsonProperty("06. volume")]
        public double volume { get; set; }
        [JsonProperty("07. latest trading day")]
        public string date { get; set; }

        [JsonProperty("08. previous close")]
        public string pc { get; set; }

        [JsonProperty("09. change")]
        public string change { get; set; }
        [JsonProperty("10. change percent")]
        public string cp { get; set; }
    }
}
