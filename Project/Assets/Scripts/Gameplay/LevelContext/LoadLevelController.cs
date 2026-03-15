using System;
using Zenject;

namespace SnakeGame.Gameplay
{
    public sealed class LoadLevelController : IInitializable, IDisposable
    {
        private readonly IGameCycle _gameCycle;
        private readonly ILevelLoader _levelLoader;

        public LoadLevelController(IGameCycle gameCycle, ILevelLoader levelLoader)
        {
            _gameCycle = gameCycle;
            _levelLoader = levelLoader;
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
            _levelLoader.LoadNextLevel();
        }
    }
}