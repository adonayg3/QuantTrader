namespace QuantTrader.Entities.CoinData;

public class CoinDayMarketData
{
    public long? MarketCapRank { get; set; }
    
    public decimal? PriceChange24H { get; set; }
    
    public double? PriceChangePercentage24H { get; set; }
    
    public decimal? MarketCapChange24H { get; set; }
    
    public decimal? MarketCapChangePercentage24H { get; set; }
    
    public string? CirculatingSupply { get; set; }
    
    public decimal? TotalSupply { get; set; }
}