using System;
using Modules;
using UnityEngine;
using Zenject;

namespace SnakeGame.Gameplay
{
    public sealed class SnakeOutBoundsController : IInitializable, IDisposable
    {
        private readonly ISnake _snake;
        private readonly IGameCycle _gameCycle;
        private readonly IWorldBounds _worldBounds;
        
        public SnakeOutBoundsController(ISnake snake, IGameCycle gameCycle, IWorldBounds worldBounds)
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
                _gameCycle.FinishGame(false);
            }
        }
    }
}