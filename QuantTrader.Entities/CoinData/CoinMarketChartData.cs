namespace QuantTrader.Entities.CoinData;

public class CoinMarketChartData
{
    public decimal?[][] Prices { get; set; }
    
    public decimal?[][] MarketCaps { get; set; }
    
    public decimal?[][] TotalVolumes { get; set; }
}