namespace StockMarketWatcherBackend
{
    public class Stock
    {
        public string Name { get; set; }
        public float PriceNow { get; set; }
        public float StartingPrice { get; set; }
        public List <float> Diff { get; set; }

        public Stock(string name, float startingPrice, float priceNow, List<float> diff)
        {
            Name = name;
            PriceNow = priceNow;
            StartingPrice = startingPrice;
            Diff = diff;
        }
    }
}
