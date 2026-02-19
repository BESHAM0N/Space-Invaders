using Game.Entities;
using UnityEngine;

namespace Game.Presentations.Reactoins
{
    public sealed class ShipMovementReaction : IShipViewReaction
    {
        private readonly ShipMovementAnimator _animator;
        
        public ShipMovementReaction(Transform viewTransform, ShipViewConfig config)
        {
            _animator = new ShipMovementAnimator();
            _animator.Init(viewTransform, config);
        }
        
        public void Bind(Ship ship) { }
        public void Unbind(Ship ship) { }

        public void Tick(Ship ship, float deltaTime)
        {
            _animator.Animate(ship.MoveDirection, deltaTime);
        }
    }
}