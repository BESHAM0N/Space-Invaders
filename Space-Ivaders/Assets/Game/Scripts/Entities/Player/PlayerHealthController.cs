using Modules.UI;
using Modules.Utils;
using UnityEngine;

namespace Game.Entities
{
    public sealed class PlayerHealthController : MonoBehaviour
    {
        [SerializeField] private Ship _playerShip;
        [SerializeField] private CameraShaker _cameraShaker;
        [SerializeField] private HealthView _healthView;
        
        private void OnEnable()
        {
            _playerShip.OnHealthChanged += HealthChanged;
        }

        private void OnDisable()
        {
            _playerShip.OnHealthChanged -= HealthChanged;
        }
        
        private void HealthChanged(int currentHealth, int maxHealth)
        {
            _healthView.SetHealth(currentHealth, maxHealth);
            _cameraShaker.Shake();
        }
    }
}