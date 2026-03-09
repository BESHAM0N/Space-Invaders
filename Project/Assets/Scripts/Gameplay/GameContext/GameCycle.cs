using System;
using UnityEngine;

namespace SnakeGame
{
    public sealed class GameCycle
    {
        public event Action OnGameStarted;
        public event Action OnGameFinished;

        public bool IsStarted { get; private set; }

        public void StartGame()
        {
            if (!IsStarted)
            {
                IsStarted = true;
                OnGameStarted?.Invoke();
                Debug.Log("Game Started!");
            }
        }

        public void FinishGame()
        {
            if (IsStarted)
            {
                IsStarted = false;
                OnGameFinished?.Invoke();
                Debug.Log("Game Finished!");
            }
        }
    }
}