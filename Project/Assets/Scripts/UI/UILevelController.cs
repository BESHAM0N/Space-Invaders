using System;
using Modules;
using Zenject;

namespace SnakeGame.UI
{
    public sealed class UILevelController : IInitializable, IDisposable
    {
        private readonly IDifficulty _difficulty;
        private readonly IGameUI _gameUI;

        public UILevelController(IGameUI gameUI, IDifficulty difficulty)
        {
            _gameUI = gameUI;
            _difficulty = difficulty;
        }
        
        public void Initialize()
        {
            _difficulty.OnStateChanged += OnUpdateLevel;
        }

        public void Dispose()
        {
            _difficulty.OnStateChanged -= OnUpdateLevel;
        }

        private void OnUpdateLevel()
        {
            _gameUI.SetDifficulty(_difficulty.Current, _difficulty.Max);
        }
    }
}