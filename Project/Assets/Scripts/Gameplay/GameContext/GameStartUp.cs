using Zenject;

namespace SnakeGame.Gameplay
{
    public sealed class GameStartUp : IInitializable
    {
        private IGameCycle _gameCycle;
      
        public  GameStartUp(IGameCycle gameCycle)
        {
            _gameCycle = gameCycle;
        }
        
        public void Initialize()
        {
            _gameCycle.StartGame();
        }
    }
}