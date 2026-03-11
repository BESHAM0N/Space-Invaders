using System;
using Modules;
using SnakeGame;
using Zenject;

namespace SnakeGame.Gameplay
{
    public sealed class LoadLevelController : IInitializable, IDisposable
    {
        private readonly IGameCycle _gameCycle;
        private readonly IDifficulty _difficulty;
        private readonly ICoinCollector _coinCollector;
        private readonly ICoinSpawner _coinSpawner;

        public LoadLevelController(IGameCycle gameCycle, IDifficulty difficulty, ICoinCollector coinCollector, ICoinSpawner coinSpawner)
        {
            _gameCycle = gameCycle;
            _difficulty = difficulty;
            _coinCollector = coinCollector;
            _coinSpawner = coinSpawner;
        }

        public void Initialize()
        {
            _gameCycle.OnGameStarted += OnLoadLevel;
        }

        public void Dispose()
        {
            _gameCycle.OnGameStarted -= OnLoadLevel;
        }

        private void OnLoadLevel()
        {
            if (!_difficulty.Next(out int nextLevelCount)) 
                return;
            
            _coinCollector.ClearCoins();
            _coinSpawner.CreateCoins(nextLevelCount);
        }
    }
}