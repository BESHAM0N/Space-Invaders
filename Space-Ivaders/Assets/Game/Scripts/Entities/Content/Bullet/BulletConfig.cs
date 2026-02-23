using UnityEngine;

namespace Game.Content
{
    public class BulletConfig
    {
        public readonly int Damage;
        public readonly float Speed;
        public readonly TeamType TeamType;
        public readonly Vector2 SpawnPosition;
        
        public BulletConfig(int damage, TeamType teamType, Vector2 spawnPosition, float speed)
        {
            Damage = damage;
            TeamType = teamType;
            SpawnPosition = spawnPosition;
            Speed = speed;
        }
        
        public void OnTriggerEnter(Collider2D other)
        {
            if (other.TryGetComponent(out Ship ship))
            {
                if (TeamType != ship.Config.TeamType)
                    ship.TakeDamage(Damage);
            }
        }
    }
}