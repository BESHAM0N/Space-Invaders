using Game.Entities;
using UnityEngine;

namespace Game.Presentations.Reactoins
{
    public sealed class ShipDeathView : MonoBehaviour
    {
        [SerializeField] private Ship _ship;
        [SerializeField] private Transform _viewTransform;
        [SerializeField] private ShipViewConfig _viewConfig;

        private void OnEnable()
        {
            _ship.OnDead += OnDead;
        }

        private void OnDisable()
        {
            _ship.OnDead -= OnDead;
        }

        private void OnDead()
        {
            var prefab = _viewConfig.DestroyEffectPrefab;
            
            if (prefab)
                Instantiate(prefab, _viewTransform.position, _viewTransform.rotation);
        }
    }
}