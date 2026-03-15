using System;
using Modules;
using Zenject;

namespace SnakeGame.Gameplay
{
    public sealed class SnakeExpandController : IInitializable, IDisposable
    {
        private readonly ISnake _snake;
        private readonly ICoinCollector _coinManager;

        public SnakeExpandController(ISnake snake, ICoinCollector coinManager)
        {
            _snake = snake;
            _coinManager = coinManager;
        }
        
        public void Initialize()
        {
            _coinManager.OnCoinPickedUp += OnCoinPickedUp;
        }

        public void Dispose()
        {
            _coinManager.OnCoinPickedUp -= OnCoinPickedUp;
        }

        private void OnCoinPickedUp(ICoin coin)
        {
            _snake.Expand(coin.Bones);
        }
    }
}