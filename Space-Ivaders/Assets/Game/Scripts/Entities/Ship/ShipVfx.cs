using UnityEngine;

namespace Game.Entities
{
    public sealed class ShipVfx
    {
        private ParticleSystem _fireVfx;
        private ShipViewConfig _viewConfig;

        public void Init(ParticleSystem fireVfx, ShipViewConfig viewConfig)
        {
            if (fireVfx == null || viewConfig == null)
            {
                Debug.LogError("ShipVfx is null");
                return;
            }
            
            _fireVfx = fireVfx;
            _viewConfig = viewConfig;
        }

        public void PlayFire()
        {
            if (_fireVfx) 
                _fireVfx.Play();
        }

        public void PlayDestroy(Vector3 pos, Quaternion rot)
        {
            var prefab = _viewConfig.DestroyEffectPrefab;
            
            if (prefab) 
                Object.Instantiate(prefab, pos, rot);
        }
    }
}