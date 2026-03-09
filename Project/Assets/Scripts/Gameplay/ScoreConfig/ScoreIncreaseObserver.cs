using System;
using Modules;
using Zenject;

namespace SnakeGame
{
    public sealed class ScoreIncreaseObserver : IInitializable, IDisposable
    {
        private readonly IScore _score;
        private readonly CoinCollector _coinCollector;

        public ScoreIncreaseObserver(IScore score, CoinCollector coinCollector)
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