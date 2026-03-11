using System;
using Modules;

namespace SnakeGame.Gameplay
{
    public interface ICoinSpawner
    {
        event Action<ICoin> OnAddCoin;

        void CreateCoins(int cout);
    }
}