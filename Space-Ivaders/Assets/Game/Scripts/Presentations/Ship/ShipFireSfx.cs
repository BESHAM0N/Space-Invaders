using UnityEngine;

namespace Game.Presentations
{
    public sealed class ShipFireSfx
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

        public void PlayFire()
        {
            if (_clip)
                _audioSource.PlayOneShot(_clip);
        }
    }
}