using System;
using Modules;
using Zenject;

namespace SnakeGame
{
    public sealed class SnakeSelfColliderObserver : IInitializable, IDisposable
    {
        private readonly ISnake _snake;
        private readonly GameCycle _gameCycle;

        public SnakeSelfColliderObserver(ISnake snake, GameCycle gameCycle)
        {
            _snake = snake;
            _gameCycle = gameCycle;
        }
        
        public void Initialize()
        {
            _snake.OnSelfCollided -= OnSelfCollider;
        }

        public void Dispose()
        {
            _snake.OnSelfCollided -= OnSelfCollider;
        }
        
        private void OnSelfCollider()
        {
            _gameCycle.FinishGame();
        }
    }
}