using QuantTrader.Entities.Shared;

namespace QuantTrader.Entities.CoinData;

public class CoinMarketData : CoinDayMarketData
{ 
    public string Id { get; set; }
    public string Symbol { get; set; }
    public string Name { get; set; }
    public Uri Image { get; set; }
    public decimal? CurrentPrice { get; set; }
    public decimal? MarketCap { get; set; }
    public decimal? TotalVolume { get; set; }
    public decimal? High24H { get; set; }
    public decimal? Low24H { get; set; }
    public decimal? Ath { get; set; }
    public decimal? AthChangePercentage { get; set; }
    public DateTimeOffset? AthDate { get; set; }
    public DateTimeOffset? LastUpdated { get; set; }
    public decimal[] PriceLast7D { get; set; }
    public decimal? PriceChangePercentage14DInCurrency { get; set; }
    public decimal? PriceChangePercentage1HInCurrency { get; set; }
    public decimal? PriceChangePercentage1YInCurrency { get; set; }
    public decimal? PriceChangePercentage200DInCurrency { get; set; }
    public decimal? PriceChangePercentage24HInCurrency { get; set; }
    public decimal? PriceChangePercentage30DInCurrency { get; set; }
    public decimal? PriceChangePercentage7DInCurrency { get; set; }
}