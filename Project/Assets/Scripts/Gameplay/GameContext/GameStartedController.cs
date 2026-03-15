using System;
using Zenject;

namespace SnakeGame.Gameplay
{
    public sealed class GameStartedController : IInitializable, IDisposable
    {
        private readonly IGameCycle _gameCycle;
        private readonly ICoinCollector _coinCollector;

        public GameStartedController(ICoinCollector coinCollector, IGameCycle gameCycle)
        {
            _coinCollector = coinCollector;
            _gameCycle = gameCycle;
        }

        public void Initialize()
        {
            _coinCollector.OnAllCoinsCollected += OnLoadNextLevel;
        }

        public void Dispose()
        {
            _coinCollector.OnAllCoinsCollected -= OnLoadNextLevel;
        }

        private void OnLoadNextLevel()
        {
            _gameCycle.StartGame();
        }
    }
}