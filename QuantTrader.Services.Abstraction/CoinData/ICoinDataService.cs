using QuantTrader.Entities.CoinData;

namespace QuantTrader.Services.Abstraction.CoinData;

public interface ICoinDataService
{
    /// <summary>
    /// List of all supported coins id, name and symbol
    /// </summary>
    /// <returns></returns>
    Task<List<BasicCoinData>> GetAllCoins(bool includePlatform = false);
    
    /// <summary>
    /// Get single coin id, name and symbol
    /// </summary>
    /// <param name="symbol"></param>
    /// <returns></returns>
    Task<BasicCoinData> GetBasicCoinData(string symbol);
}