namespace Shares.Models
{
    public class Stock
    {
        public int shareId { get; set; }
        public string shareName { get; set; }
        public string shareSymbol { get; set; }
        public double boughtPrice { get; set; }
        public double stocks  { get; set; }
        public DateTime date { get; set; }
        public int userid { get; set; }
        public double boughtValue { get; set; }
        public double actualValue { get; set; }
        public double profit { get; set; }
    }
}
