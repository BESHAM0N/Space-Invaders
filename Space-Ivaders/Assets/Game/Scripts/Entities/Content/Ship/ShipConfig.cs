using UnityEngine;

namespace Game
{
    // +
    [CreateAssetMenu(menuName = "Game/ShipConfig", order = 0)]
    public sealed class ShipConfig : ScriptableObject
    {
        [Header("Core")]
        [field: SerializeField]
        public int Health { get; private set; } = 5;

        [field: SerializeField]
        public float MoveSpeed { get; private set; } = 5;

        [field: SerializeField]
        public float FireCooldown { get; private set; } = 0.25f;
        
        [field: SerializeField]
        public int Damage { get; private set; } = 1;
        
        [field: SerializeField]
        public TeamType TeamType { get; private set; } = TeamType.None;
    }
}