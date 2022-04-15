using CoinGecko.Clients;
using CoinGecko.Interfaces;
using QuantTrader.Entities.CoinData;

namespace QuantTrader.Shared.ApiClient;

public class CoinGeckoApiClient : ICoinApiClient
{
    private readonly ICoinGeckoClient _client;
    
    public CoinGeckoApiClient()
    {
        _client = CoinGeckoClient.Instance;
    }

    public async Task<List<BasicCoinData>> GetAllCoins(bool includePlatforms)
    {
         var coinList = await _client.CoinsClient.GetCoinList(includePlatforms);
         return coinList.Select(coin => new BasicCoinData()
         {
             Id = coin.Id,
             Symbol = coin.Symbol,
             Name = coin.Name,
             Platforms = coin.Platforms
         }).ToList();
    }

    public async Task<BasicCoinData> GetBasicCoinData(string symbol)
    {
        var coinList = await _client.CoinsClient.GetCoinList();
        var coin = coinList.FirstOrDefault(coin => coin.Symbol == symbol);
        return new BasicCoinData()
        {
            Id = coin?.Id,
            Symbol = coin?.Symbol,
            Name = coin?.Name,
            Platforms = coin?.Platforms
        };
    }
}