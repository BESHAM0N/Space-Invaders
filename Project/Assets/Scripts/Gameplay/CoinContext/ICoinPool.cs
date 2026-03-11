using Modules;
using UnityEngine;

namespace SnakeGame.Gameplay
{
    public interface ICoinPool
    {
        ICoin Spawn(Vector2Int position);
        void Despawn(ICoin coin);
    }
}