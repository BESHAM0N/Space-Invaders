using Game.Entities;
using Game.Presentations.Reactoins;
using UnityEngine;

namespace Game.Presentations
{
    public sealed class ShipPresentation : MonoBehaviour
    {
        [SerializeField] private Ship _ship;
        [SerializeField] private ShipViewConfig _viewConfig;

        [Header("Refs")] 
        [SerializeField] private Transform _viewTransform;
        [SerializeField] private Renderer _renderer;
        [SerializeField] private ParticleSystem _fireVfx;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _fireSfx;
        [SerializeField] private AudioClip _damageSfx;

        private IShipViewReaction[] _reactions;

        private void Awake()
        {
            _reactions = new IShipViewReaction[]
            {
                new ShipMovementReaction(_viewTransform, _viewConfig),
                new ShipFireReaction(_fireVfx, _audioSource, _fireSfx),
                new ShipDamageReaction(_renderer, _viewConfig, _audioSource, _damageSfx),
                new ShipDeathReaction(_viewTransform, _viewConfig),
            };
        }
        private void OnEnable()
        {
            foreach (var reaction in _reactions) 
                reaction.Bind(_ship);
        }

        private void OnDisable()
        {
            foreach (var reaction in _reactions) 
                reaction.Unbind(_ship);
        }

        private void LateUpdate()
        {
            float deltaTime = Time.deltaTime;
            
            foreach (var reaction in _reactions) 
                reaction.Tick(_ship, deltaTime);
        }
    }
}