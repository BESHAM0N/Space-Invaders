using Modules.Utils;
using UnityEngine;

namespace Game.Entities
{
    public sealed class CameraShakerController : MonoBehaviour
    {
        [SerializeField] private Ship _playerShip;
        [SerializeField] private CameraShaker _cameraShaker;
        
        private void OnEnable()
        {
            _playerShip.OnHealthChanged += CameraShake;
        }

        private void OnDisable()
        {
            _playerShip.OnHealthChanged -= CameraShake;
        }
        
        private void CameraShake(int currentHealth, int maxHealth)
        {
            _cameraShaker.Shake();
        }
    }
}