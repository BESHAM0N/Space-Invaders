using System;

namespace SnakeGame.Gameplay
{
    public interface IGameCycle
    {
        event Action OnGameStarted;
        event Action<bool> OnGameFinished;

        void StartGame();
        void FinishGame(bool victory);
    }
}