using Modules.Utils;
using UnityEngine;

namespace Game.Entities
{
    // +
    public sealed class BoundsClamp : MonoBehaviour
    {
        [SerializeField] private TransformBounds _playerArea;

        private void LateUpdate()
        {
            transform.position = _playerArea.ClampInBounds(transform.position);
        }
    }
}