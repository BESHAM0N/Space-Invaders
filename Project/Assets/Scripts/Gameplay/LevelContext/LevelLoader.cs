using Modules;

namespace SnakeGame.Gameplay
{
    public sealed class LevelLoader : ILevelLoader
    {
        private readonly IGameCycle _gameCycle;
        private readonly IDifficulty _difficulty;
        private readonly ICoinCollector _coinCollector;
        private readonly ICoinSpawner _coinSpawner;

        public LevelLoader(IGameCycle gameCycle, IDifficulty difficulty, ICoinCollector coinCollector, ICoinSpawner coinSpawner)
        {
            _gameCycle = gameCycle;
            _difficulty = difficulty;
            _coinCollector = coinCollector;
            _coinSpawner = coinSpawner;
        }

        public void LoadNextLevel()
        {
            if (!_difficulty.Next(out var nextLevelCount))
            {
                _gameCycle.FinishGame(true);
                return;
            }

            _coinCollector.ClearCoins();
            _coinSpawner.CreateCoins(nextLevelCount);
        }
    }
}