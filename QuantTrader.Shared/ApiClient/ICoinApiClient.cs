using QuantTrader.Entities.CoinData;

namespace QuantTrader.Shared.ApiClient;

public interface ICoinApiClient
{
    Task<List<BasicCoinData>> GetAllCoins(bool includePlatform = false);
    Task<BasicCoinData> GetBasicCoinData(string symbol);
}