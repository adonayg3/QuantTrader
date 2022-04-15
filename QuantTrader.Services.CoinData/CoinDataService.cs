using QuantTrader.Entities.CoinData;
using QuantTrader.Services.Abstraction.CoinData;
using QuantTrader.Shared.ApiClient;

namespace QuantTrader.Services.CoinData;

public class CoinDataService : ICoinDataService
{
    private readonly ICoinApiClient _coinApiClient;

    public CoinDataService(ICoinApiClient coinApiClient)
    {
        _coinApiClient = coinApiClient;
    }
    
    public Task<List<BasicCoinData>> GetAllCoins(bool includePlatform = false)
    {
        return _coinApiClient.GetAllCoins();
    }

    public Task<BasicCoinData> GetBasicCoinData(string symbol)
    {
        return _coinApiClient.GetBasicCoinData(symbol);
    }
}