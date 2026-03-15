using System;
using Modules;

namespace SnakeGame.Gameplay
{
    public sealed class CoinSpawner : ICoinSpawner
    {
        public event Action<ICoin> OnAddCoin;
        
        private readonly IWorldBounds _worldBounds;
        private readonly ICoinPool _coinPool;
        
        public CoinSpawner(IWorldBounds worldBounds, ICoinPool coinPool)
        {
            _worldBounds = worldBounds;
            _coinPool = coinPool;
        }
        
        public void CreateCoins(int cout)
        {
            for (var i = 0; i < cout; i++)
            {
                var position = _worldBounds.GetRandomPosition();
                var coin = _coinPool.Spawn(position);
                
                if (coin != null)
                    OnAddCoin?.Invoke(coin);
            }
        }
    }
}