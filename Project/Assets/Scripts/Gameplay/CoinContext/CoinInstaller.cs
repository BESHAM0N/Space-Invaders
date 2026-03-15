using System;
using Modules;
using UnityEngine;
using Zenject;

namespace SnakeGame.Gameplay
{
    [Serializable]
    public sealed class CoinInstaller : Installer
    {
        [SerializeField] private Coin _coinPrefab;
        [SerializeField] private Transform _worldTransform;

        private const int INITIAL_SIZE = 1;
        private const int MAX_SIZE = 10;
        
        public override void InstallBindings()
        {
            Container
                .BindMemoryPool<Coin, CoinPool>()
                .WithInitialSize(INITIAL_SIZE)
                .WithMaxSize(MAX_SIZE)
                .ExpandByOneAtATime()
                .FromComponentInNewPrefab(_coinPrefab)
                .WithGameObjectName("Coin")
                .UnderTransform(_worldTransform)
                .AsSingle();

            Container
                .Bind<ICoinPool>()
                .To<CoinPool>()
                .FromResolve();
            
            Container
                .BindInterfacesAndSelfTo<CoinCollector>()
                .AsSingle()
                .NonLazy();
            
            Container
                .BindInterfacesAndSelfTo<CoinSpawner>()
                .AsSingle();
            
            Container
                .BindInterfacesAndSelfTo<AddCoinController>()
                .AsSingle();
        }
    }
}