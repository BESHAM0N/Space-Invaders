using System;
using Zenject;

namespace SnakeGame.Gameplay
{
    public sealed class AllCoinsCollectedObserver : IInitializable, IDisposable
    {
        private readonly IGameCycle _gameCycle;
        private readonly ICoinCollector _coinCollector;

        public AllCoinsCollectedObserver(IGameCycle gameCycle, ICoinCollector coinCollector)
        {
            _gameCycle = gameCycle;
            _coinCollector = coinCollector;
        }
        
        public void Initialize()
        {
            _coinCollector.OnAllCoinsCollected += OnGameOver;
        }

        public void Dispose()
        {
            _coinCollector.OnAllCoinsCollected -= OnGameOver;
        }

        private void OnGameOver()
        {
            _gameCycle.FinishGame(true);
        }
    }
}