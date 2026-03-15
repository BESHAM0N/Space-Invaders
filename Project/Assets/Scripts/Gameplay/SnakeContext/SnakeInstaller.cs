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
            if (_snakePrefab == null)
                throw new Exception("Snake prefab is not assigned.");
         
            Container
                .Bind<ISnake>()
                .To<Snake>()
                .FromComponentInNewPrefab(_snakePrefab)
                .WithGameObjectName("Snake")
                .AsSingle();
        
            Container
                .BindInterfacesAndSelfTo<SnakeMoveController>()
                .AsSingle();
            
            Container.BindInterfacesAndSelfTo<SnakeExpandObserver>().AsSingle().NonLazy();;
            Container.BindInterfacesAndSelfTo<SnakeSpeedObserver>().AsSingle().NonLazy();;
            Container.BindInterfacesAndSelfTo<SnakeSelfColliderObserver>().AsSingle().NonLazy();;
            Container.BindInterfacesAndSelfTo<SnakeOutBoundsObserver>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<SnakePickupCoinObserver>().AsSingle().NonLazy();
        }
    }
}