using UnityEngine;

namespace Game.Presentations
{
    public sealed class ShipDamageSfx
    {
        private AudioSource _audioSource;
        private AudioClip _clip;

        public void Init(AudioSource audioSource, AudioClip clip)
        {
            if (audioSource == null || clip == null)
            {
                return;
            }

            _audioSource = audioSource;
            _clip = clip;
        }

        public void PlayDamage()
        {
            if (_clip)
                _audioSource.PlayOneShot(_clip);
        }
    }
}