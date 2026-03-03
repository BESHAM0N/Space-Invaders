using Modules.UI;
using UnityEngine;
using Game.Content;

namespace Game.Systems
{
    public sealed class PlayerHealthViewController : MonoBehaviour
    {
        [SerializeField] private Ship _playerShip;
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
        }
    }
}