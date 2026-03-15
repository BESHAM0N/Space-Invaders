using System;
using Modules;
using Zenject;

namespace SnakeGame.Gameplay
{
    public sealed class ScoreIncreaseController : IInitializable, IDisposable
    {
        private readonly IScore _score;
        private readonly ICoinCollector _coinCollector;

        public ScoreIncreaseController(IScore score, ICoinCollector coinCollector)
        {
            _score = score;
            _coinCollector = coinCollector;
        }
        
        public void Initialize()
        {
            _coinCollector.OnCoinPickedUp += OnCoinPickedUp;
        }

        public void Dispose()
        {
            _coinCollector.OnCoinPickedUp -= OnCoinPickedUp;
        }
        
        private void OnCoinPickedUp(ICoin coin)
        {
            _score.Add(coin.Score);
        }
    }
}