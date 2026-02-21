using Game.Entities;
using UnityEngine;

namespace Game.Presentations.Reactoins
{
    public sealed class ShipMovementView : MonoBehaviour
    {
        [SerializeField] private Ship _ship;
        [SerializeField] private ShipViewConfig _viewConfig;
        [SerializeField] private Transform _viewTransform;
      
        private const float Y_ROTATION_SCALE = 0.5f;
        private const float Y_ROTATION_SIGN = -1f;

        private void LateUpdate()
        {
            Animate();
        }

        private void Animate()
        {
            Vector3 angles = _viewTransform.localEulerAngles;
            angles.x = _viewConfig.MoveRotationAngle * _ship.MoveDirection.y;
            angles.y = _viewConfig.MoveRotationAngle * Y_ROTATION_SCALE * _ship.MoveDirection.x * Y_ROTATION_SIGN;

            Quaternion target = Quaternion.Euler(angles);
            float t = _viewConfig.MoveSpeed * Time.deltaTime;
            _viewTransform.localRotation = Quaternion.Lerp(_viewTransform.localRotation, target, t);
        }
    }
}