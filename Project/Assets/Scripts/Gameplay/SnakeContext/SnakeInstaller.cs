using System;
using Modules;
using UnityEngine;
using Zenject;

namespace SnakeGame.Gameplay
{
    [Serializable]
    public sealed class SnakeInstaller : Installer
    {
        [SerializeField] private Snake _snakePrefab;
    
        public override void InstallBindings()
        {
            Container
                .Bind<ISnake>()
                .To<Snake>()
                .FromComponentInNewPrefab(_snakePrefab)
                .WithGameObjectName("Snake")
                .AsSingle();
        
            Container
                .BindInterfacesAndSelfTo<SnakeMoveController>()
                .AsSingle();
            
            Container
                .BindInterfacesAndSelfTo<SnakeExpandController>()
                .AsSingle()
                .NonLazy();
            
            Container
                .BindInterfacesAndSelfTo<SnakeSpeedController>()
                .AsSingle()
                .NonLazy();
            
            Container
                .BindInterfacesAndSelfTo<SnakeSelfColliderController>()
                .AsSingle()
                .NonLazy();
            
            Container
                .BindInterfacesAndSelfTo<SnakeOutBoundsController>()
                .AsSingle()
                .NonLazy();
            
            Container
                .BindInterfacesAndSelfTo<SnakePickupCoinController>()
                .AsSingle()
                .NonLazy();
        }
    }
}