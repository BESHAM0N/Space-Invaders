using Game.Entities;
using UnityEngine;

namespace Game.Presentations.Reactoins
{
    public sealed class ShipFireReaction : IShipViewReaction
    {
        private readonly ShipFireVfx _vfx;
        private readonly ShipFireSfx _sfx;

        public ShipFireReaction(ParticleSystem fireVfx, AudioSource audio, AudioClip fireClip)
        {
            _vfx = new ShipFireVfx();
            _vfx.Init(fireVfx);

            _sfx = new ShipFireSfx();
            _sfx.Init(audio, fireClip);
        }
        
        public void Bind(Ship ship) => ship.OnFire += OnFire;
        public void Unbind(Ship ship) => ship.OnFire -= OnFire;
        
        public void Tick(Ship ship, float deltaTime) { }

        private void OnFire()
        {
            _sfx.PlayFire();
            _vfx.PlayFire();
        }
    }
}