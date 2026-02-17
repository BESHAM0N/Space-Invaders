using Game.Entities;
using UnityEngine;

namespace Game.Presentations
{
    public sealed class BulletVfxController : MonoBehaviour
    {
        private Bullet _bullet;
        private BulletPresentation _bulletPresentation;

        private void Awake()
        {
            _bullet = gameObject.GetComponent<Bullet>();
            _bulletPresentation = gameObject.GetComponent<BulletPresentation>();
        }

        private void OnEnable()
        {
            _bullet.OnTriggerEntered += VfxPlay;
        }

        private void OnDisable()
        {
            _bullet.OnTriggerEntered -= VfxPlay;
        }

        private void VfxPlay(Bullet bullet, Collider2D other)
        {
            if (other.TryGetComponent(out Ship ship))
                _bulletPresentation.ExplosionVFXPlay(ship);
        }
    }
}