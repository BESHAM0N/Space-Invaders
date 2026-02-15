using UnityEngine;

namespace Game.Pool
{
    public sealed class BulletPool : EntityPool<Bullet>
    {
        [SerializeField] private Transform _worldTransform;

        protected override void OnGetEntity(Bullet bullet)
        {
            //bullet.transform.SetParent(_worldTransform);
            bullet.gameObject.SetActive(true);
        }
    }
}