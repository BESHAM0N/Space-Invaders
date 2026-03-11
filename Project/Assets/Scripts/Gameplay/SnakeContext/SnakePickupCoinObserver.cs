using System;
using Modules;
using UnityEngine;
using Zenject;

namespace SnakeGame.Gameplay
{
    public sealed class SnakePickupCoinObserver : IInitializable, IDisposable
    {
        private readonly ISnake _snake;
        private readonly ICoinCollector _coinCollector;

        public SnakePickupCoinObserver(ISnake snake, ICoinCollector coinCollector)
        {
            _snake = snake;
            _coinCollector = coinCollector;
        }
        
        public void Initialize()
        {
            _snake.OnMoved += OnTryPickUpCoin;
        }

        public void Dispose()
        {
            _snake.OnMoved -= OnTryPickUpCoin;
        }
        
        private void OnTryPickUpCoin(Vector2Int position)
        {
            _coinCollector.TryPickUpCoin(position);
        }
    }
}