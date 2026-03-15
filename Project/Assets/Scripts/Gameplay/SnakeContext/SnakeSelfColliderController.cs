using System;
using Modules;
using Zenject;

namespace SnakeGame.Gameplay
{
    public sealed class SnakeSelfColliderController : IInitializable, IDisposable
    {
        private readonly ISnake _snake;
        private readonly IGameCycle _gameCycle;

        public SnakeSelfColliderController(ISnake snake, IGameCycle gameCycle)
        {
            _snake = snake;
            _gameCycle = gameCycle;
        }
        
        public void Initialize()
        {
            _snake.OnSelfCollided += OnSelfCollider;
        }

        public void Dispose()
        {
            _snake.OnSelfCollided -= OnSelfCollider;
        }
        
        private void OnSelfCollider()
        {
            _gameCycle.FinishGame(false);
        }
    }
}