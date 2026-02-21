using Game.Entities;
using UnityEngine;

namespace Game
{
    public class BulletConfig
    {
        public readonly int Damage;
        public readonly TeamType TeamType;
        public readonly Vector2 Position;

        public BulletConfig(int damage, TeamType teamType, Vector2 position)
        {
            Damage = damage;
            TeamType = teamType;
            Position = position;
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