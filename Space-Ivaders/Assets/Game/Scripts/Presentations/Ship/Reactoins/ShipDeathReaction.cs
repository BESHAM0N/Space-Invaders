using Game.Entities;
using UnityEngine;

namespace Game.Presentations.Reactoins
{
    public sealed class ShipDeathReaction : IShipViewReaction
    {
        private readonly ShipDestroyVfx _vfx;
        private readonly Transform _viewTransform;

        public ShipDeathReaction(Transform viewTransform, ShipViewConfig config)
        {
            _viewTransform = viewTransform;

            _vfx = new ShipDestroyVfx();
            _vfx.Init(config);
        }

        public void Bind(Ship ship) => ship.OnDead += OnDead;
        public void Unbind(Ship ship) => ship.OnDead -= OnDead;
        
        public void Tick(Ship ship, float deltaTime) { }

        private void OnDead()
        {
            _vfx.PlayDestroy(_viewTransform.position, _viewTransform.rotation);
        }
    }
}