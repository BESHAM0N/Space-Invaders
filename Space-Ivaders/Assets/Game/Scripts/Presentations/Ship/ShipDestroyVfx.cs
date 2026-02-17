using UnityEngine;

namespace Game.Presentations
{
    public sealed class ShipDestroyVfx
    {
        private ShipViewConfig _viewConfig;

        public void Init(ShipViewConfig viewConfig)
        {
            if (viewConfig == null)
            {
                return;
            }

            _viewConfig = viewConfig;
        }

        public void PlayDestroy(Vector3 position, Quaternion rotation)
        {
            var prefab = _viewConfig.DestroyEffectPrefab;
            
            if (prefab)
                Object.Instantiate(prefab, position, rotation);
        }
    }
}