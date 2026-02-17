using Game.Entities;
using UnityEngine;

namespace Game.Presentations.Reactoins
{
    public sealed class ShipDamageReaction : IShipViewReaction
    {
        private readonly ShipMaterialHitEffect _hit;
        private readonly ShipDamageSfx _sfx;

        public ShipDamageReaction(Renderer renderer, ShipViewConfig config, AudioSource audio, AudioClip damageClip)
        {
            _hit = new ShipMaterialHitEffect();
            _hit.Init(renderer, config);

            _sfx = new ShipDamageSfx();
            _sfx.Init(audio, damageClip);
        }
        
        public void Bind(Ship ship) => ship.OnHealthChanged += OnHealthChanged;
        public void Unbind(Ship ship) => ship.OnHealthChanged -= OnHealthChanged;

        public void Tick(Ship ship, float deltaTime){ }
        
        private void OnHealthChanged(int current, int max)
        {
            if (current <= 0) return;
            _hit.PlayHit();
            _sfx.PlayDamage();
        }
    }
}