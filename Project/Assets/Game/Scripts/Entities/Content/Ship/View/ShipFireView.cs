using UnityEngine;

namespace Game.Content
{
    public sealed class ShipFireView : MonoBehaviour
    {
        [SerializeField] private Ship _ship;
        [SerializeField] private ParticleSystem _fireVfx;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _fireSfx;

        private void OnEnable()
        {
            _ship.OnFire += OnFire;
        }

        private void OnDisable()
        {
            _ship.OnFire -= OnFire;
        }

        private void OnFire()
        {
            _audioSource.PlayOneShot(_fireSfx);
            _fireVfx.Play();
        }
    }
}