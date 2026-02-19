using UnityEngine;

namespace Game
{
    public readonly struct BulletConfig
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
    }
}