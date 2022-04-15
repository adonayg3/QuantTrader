namespace QuantTrader.Entities.CoinData;

public class BasicCoinData
{
    public string? Id { get; set; }
    public string? Symbol { get; set; }
    public string? Name { get; set; }
    public Dictionary<string,string>? Platforms { get; set; }
}