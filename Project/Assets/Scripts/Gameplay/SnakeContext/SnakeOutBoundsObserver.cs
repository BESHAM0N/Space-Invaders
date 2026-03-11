using System;
using Modules;
using UnityEngine;
using Zenject;

namespace SnakeGame.Gameplay
{
    public sealed class SnakeOutBoundsObserver : IInitializable, IDisposable
    {
        private readonly ISnake _snake;
        private readonly IGameCycle _gameCycle;
        private readonly IWorldBounds _worldBounds;
        
        public SnakeOutBoundsObserver(ISnake snake, IGameCycle gameCycle, IWorldBounds worldBounds)
        {
            _snake = snake;
            _gameCycle = gameCycle;
            _worldBounds = worldBounds;
        }
        
        public void Initialize()
        {
            _snake.OnMoved += OnMoved;
        }

        public void Dispose()
        {
            _snake.OnMoved -= OnMoved;
        }

        private void OnMoved(Vector2Int position)
        {
            if (!_worldBounds.IsInBounds(position))
            {
                Debug.Log("Snake is out of bounds. Game Over.");
                _gameCycle.FinishGame(false);
            }
        }
    }
}