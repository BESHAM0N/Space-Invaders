using System;
using SnakeGame.Gameplay;
using Zenject;

namespace SnakeGame.UI
{
    public sealed class UIGameOverObserver : IInitializable, IDisposable
    {
        private readonly IGameUI _gameUI;
        private readonly IGameCycle _gameCycle;

        public UIGameOverObserver(IGameUI gameUI, IGameCycle gameCycle)
        {
            _gameCycle = gameCycle;
            _gameUI = gameUI;
        }

        public void Initialize()
        {
            _gameCycle.OnGameFinished += OnFinishGame;
        }

        public void Dispose()
        {
            _gameCycle.OnGameFinished -= OnFinishGame;
        }

        private void OnFinishGame(bool victory)
        {
            _gameUI.GameOver(victory);
        }
    }
}