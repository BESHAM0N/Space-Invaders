using Game.Entities;
using Modules.Utils;
using UnityEngine;

namespace Game
{
    // +
    public sealed class PlayerShip : Ship
    {
        [SerializeField] private TransformBounds _playerArea;
        [SerializeField] private BulletManager _bulletManager;

        private void Awake()
        {
            SetBulletManager(_bulletManager);
        }

        private void LateUpdate()
        {
            transform.position = _playerArea.ClampInBounds(transform.position);
        }
    }
}