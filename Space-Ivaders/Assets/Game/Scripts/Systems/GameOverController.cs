using Game.Entities;
using Modules.UI;
using UnityEngine;

namespace Game
{
    public sealed class GameOverController : MonoBehaviour
    {
        [SerializeField] private Ship _playerShip;
        [SerializeField] private GameOverView _gameOverView;
        
        private void OnEnable()
        {
            _playerShip.OnDead += GameOver;
        }

        private void OnDisable()
        {
            _playerShip.OnDead -= GameOver;
        }
        
        private  void GameOver()
        {
            _gameOverView.Show();
        }
    }
}