using System;
using Modules;
using Unity.VisualScripting;

namespace SnakeGame.Gameplay
{
    public sealed class AddCoinController : IInitializable, IDisposable
    {
        private readonly ICoinSpawner _coinSpawner;
        private readonly ICoinCollector _coinCollector;

        public AddCoinController(ICoinSpawner coinSpawner, ICoinCollector coinCollector)
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