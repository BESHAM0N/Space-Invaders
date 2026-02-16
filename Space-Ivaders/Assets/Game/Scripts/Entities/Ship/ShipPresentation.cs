using UnityEngine;

namespace Game.Entities
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

        private ShipMaterialHitEffect _hitEffect;
        private ShipVfx _vfx;
        private ShipSfx _sfx;
        private ShipMovementAnimator _movement;

        private void Awake()
        {
            _hitEffect = new ShipMaterialHitEffect();
            _hitEffect.Init(_renderer, _viewConfig);
            
            _vfx = new ShipVfx();
            _vfx.Init(_fireVfx, _viewConfig);
            
            _sfx = new ShipSfx();
            _sfx.Init(_audioSource, _fireSfx, _damageSfx);
            
            _movement = new ShipMovementAnimator();
            _movement.Init(_viewTransform, _viewConfig);
        }

        private void OnEnable()
        {
            _ship.OnFire += HandleFire;
            _ship.OnHealthChanged += HandleHealthChanged;
            _ship.OnDead += HandleDead;
        }

        private void OnDisable()
        {
            _ship.OnFire -= HandleFire;
            _ship.OnHealthChanged -= HandleHealthChanged;
            _ship.OnDead -= HandleDead;
        }

        private void LateUpdate()
        {
            _movement.Animate(_ship.MoveDirection, Time.deltaTime);
        }

        private void HandleFire()
        {
            _sfx.PlayFire();
            _vfx.PlayFire();
        }

        private void HandleHealthChanged(int current, int max)
        {
            if (current > 0)
            {
                _hitEffect.PlayHit();
                _sfx.PlayDamage();
            }
        }

        private void HandleDead()
        {
            _vfx.PlayDestroy(_viewTransform.position, _viewTransform.rotation);
        }
    }
}