using System;
using Modules;
using UnityEngine;
using Zenject;

namespace SnakeGame.Gameplay
{
    public sealed class SnakePickupCoinController : IInitializable, IDisposable
    {
        private readonly ISnake _snake;
        private readonly ICoinCollector _coinCollector;

        public SnakePickupCoinController(ISnake snake, ICoinCollector coinCollector)
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