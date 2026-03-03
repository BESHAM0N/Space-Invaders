using Modules.Utils;
using UnityEngine;

namespace Game.Content
{
    // +
    public sealed class BoundsClamp : MonoBehaviour
    {
        [SerializeField] private TransformBounds _playerArea;
        [SerializeField] private GameObject _playerShip;

        private void LateUpdate()
        {
            _playerShip.transform.position = _playerArea.ClampInBounds(_playerShip.transform.position);
        }
    }
}