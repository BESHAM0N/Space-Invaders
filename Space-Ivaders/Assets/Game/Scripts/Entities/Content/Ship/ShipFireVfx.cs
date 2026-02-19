using UnityEngine;

namespace Game.Presentations
{
    public sealed class ShipFireVfx
    {
        private ParticleSystem _fireVfx;

        public void Init(ParticleSystem fireVfx)
        {
            if (fireVfx == null)
                return;

            _fireVfx = fireVfx;
        }

        public void PlayFire()
        {
            if (_fireVfx)
                _fireVfx.Play();
        }
    }
}