using Game.Entities;

namespace Game
{
    public interface IShipViewReaction
    {
        void Bind(Ship ship);
        void Unbind(Ship ship);
        void Tick(Ship ship, float deltaTime);
    }
}