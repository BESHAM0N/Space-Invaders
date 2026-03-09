using System;
using System.Collections.Generic;
using Modules;
using UnityEngine;

namespace SnakeGame
{
    public sealed class CoinCollector
    {
        public event Action OnAllCoinsCollected;
        public event Action<ICoin> OnCoinPickedUp;
        
        private readonly List<ICoin> _activeCoins = new();
        private readonly ICoinPool _coinPool;
        
        public bool TryPickUpCoin(Vector2Int position)
        {
            foreach (var coin in _activeCoins.ToArray())
            {
                if (coin.Position != position) 
                    continue;
                
                OnCoinPickedUp?.Invoke(coin);

                _coinPool.Despawn(coin);
                _activeCoins.Remove(coin);

                if (_activeCoins.Count == 0)
                    OnAllCoinsCollected?.Invoke();

                return true;
            }
            return false;
        }
        
        public void ClearCoins()
        {
            _activeCoins.Clear();
        }
        
        public void AddCoin(ICoin coin)
        {
            _activeCoins.Add(coin);
        }
    }
}