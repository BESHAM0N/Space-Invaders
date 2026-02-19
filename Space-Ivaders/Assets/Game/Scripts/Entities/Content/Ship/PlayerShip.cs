using Modules.Utils;
using UnityEngine;

namespace Game.Entities
{
    // +
    public sealed class PlayerShip : Ship
    {
        [SerializeField] private TransformBounds _playerArea;

        private void LateUpdate()
        {
            transform.position = _playerArea.ClampInBounds(transform.position);
        }
    }
}