using UnityEngine;

namespace Game.Content
{
    [CreateAssetMenu(menuName = "Game/Bullet Config")]
    public class BulletConfig : ScriptableObject
    {
        [field: SerializeField] private int _damage;
        [field: SerializeField] private float _speed;
        
        public TeamType TeamType;

        public Vector2 GetVelocity(Vector2 direction)
        {
            return direction * _speed;
        }
        
        public void DealDamage(Collider2D other)
        {
            if (other.TryGetComponent(out Ship ship))
            {
                if (TeamType != ship.TeamType)
                    ship.TakeDamage(_damage);
            }
        }
    }
}
