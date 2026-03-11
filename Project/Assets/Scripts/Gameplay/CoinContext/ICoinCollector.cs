using System;
using Modules;
using UnityEngine;

namespace SnakeGame.Gameplay
{
    public interface ICoinCollector
    {
         event Action OnAllCoinsCollected;
         event Action<ICoin> OnCoinPickedUp;

         bool TryPickUpCoin(Vector2Int position);
         public void ClearCoins();
         public void AddCoin(ICoin coin);
    }
}