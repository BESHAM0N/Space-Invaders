using System;

namespace SnakeGame.Gameplay
{
    public sealed class GameCycle : IGameCycle
    {
        public event Action OnGameStarted;
        public event Action<bool> OnGameFinished;

        public void StartGame()
        {
            OnGameStarted?.Invoke();
        }

        public void FinishGame(bool victory)
        {
            OnGameFinished?.Invoke(victory);
        }
    }
}