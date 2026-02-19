using UnityEngine;

namespace Game.Presentations
{
    public sealed class ShipMovementAnimator
    {
        private Transform _viewTransform;
        private ShipViewConfig _viewConfig;
        
        private const float Y_ROTATION_SCALE = 0.5f;
        private const float Y_ROTATION_SIGN = -1f;
        
        public void Init(Transform viewTransform, ShipViewConfig viewConfig)
        {
            if (viewTransform == null || viewConfig == null)
            {
                Debug.LogError("ShipMovementAnimator is null");
                return;
            }

            _viewTransform = viewTransform;
            _viewConfig = viewConfig;
        }
        
        public void Animate(Vector3 moveDirection, float dt)
        {
            Vector3 angles = _viewTransform.localEulerAngles;
            angles.x = _viewConfig.MoveRotationAngle * moveDirection.y;
            angles.y = _viewConfig.MoveRotationAngle * Y_ROTATION_SCALE * moveDirection.x * Y_ROTATION_SIGN;

            Quaternion target = Quaternion.Euler(angles);
            float t = _viewConfig.MoveSpeed * dt;
            _viewTransform.localRotation = Quaternion.Lerp(_viewTransform.localRotation, target, t);
        }
    }
}