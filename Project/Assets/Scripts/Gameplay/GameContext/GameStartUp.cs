using UnityEngine;
using Zenject;

namespace SnakeGame.Gameplay
{
    public sealed class GameStartUp : MonoBehaviour
    {
        private IGameCycle _gameCycle;

        [Inject]
        public void Construct(IGameCycle gameCycle)
        {
            _gameCycle = gameCycle;
        }

        private void Start()
        {
            _gameCycle.StartGame();
        }
    }
}