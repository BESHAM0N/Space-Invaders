using UnityEngine;

namespace Game.Entities
{
    public sealed class ShipSfx
    {
        private AudioSource _audioSource;
        private AudioClip _fireSfx;
        private AudioClip _damageSfx;

        public void Init(AudioSource audioSource, AudioClip fireSfx, AudioClip damageSfx)
        {
            if (audioSource == null || fireSfx == null || damageSfx == null)
            {
                Debug.LogError("ShipSfx is null");
                return;
            }

            _audioSource = audioSource;
            _fireSfx = fireSfx;
            _damageSfx = damageSfx;
        }

        public void PlayFire()
        {
            if (_fireSfx)
                _audioSource.PlayOneShot(_fireSfx);
        }

        public void PlayDamage()
        {
            if (_damageSfx)
                _audioSource.PlayOneShot(_damageSfx);
        }
    }
}