using System;
using Modules;
using Unity.VisualScripting;

namespace SnakeGame
{
    public sealed class AddCoinController : IInitializable, IDisposable
    {
        private readonly CoinSpawner _coinSpawner;
        private readonly CoinCollector _coinCollector;

        public AddCoinController(CoinSpawner coinSpawner, CoinCollector coinCollector)
        {
            _coinSpawner = coinSpawner;
            _coinCollector = coinCollector;
        }
        
        public void Initialize()
        {
            _coinSpawner.OnAddCoin += _coinCollector.AddCoin;
        }

        public void Dispose()
        {
            _coinSpawner.OnAddCoin -= _coinCollector.AddCoin;
        }
    }
}