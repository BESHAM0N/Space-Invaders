using System;
using Modules;
using Zenject;

namespace SnakeGame.UI
{
    public sealed class UIScoreController : IInitializable, IDisposable
    {
        private readonly IScore _score;
        private readonly IGameUI _gameUI;

        public UIScoreController(IGameUI gameUI, IScore score)
        {
            _gameUI = gameUI;
            _score = score;
        }
        
        public void Initialize()
        {
            _score.OnStateChanged += OnUpdateScore;
        }

        public void Dispose()
        {
            _score.OnStateChanged -= OnUpdateScore;
        }

        private void OnUpdateScore(int currentScore)
        {
            _gameUI.SetScore(currentScore.ToString());
        }
    }
}