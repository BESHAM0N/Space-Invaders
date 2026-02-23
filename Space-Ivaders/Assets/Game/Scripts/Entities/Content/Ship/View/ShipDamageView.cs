using DG.Tweening;
using UnityEngine;

namespace Game.Content
{
    public sealed class ShipDamageView : MonoBehaviour
    {
        [SerializeField] private Ship _ship;
        [SerializeField] private ShipViewConfig _viewConfig;
        [SerializeField] private Renderer _renderer;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _damageSfx;
        
        private Material _material;
        private Tweener _tween;
        
        private const float HIT_ANIMATION_START = 0f;
        private const float HIT_ANIMATION_END = 1f;

        private void OnEnable()
        {
            _ship.OnHealthChanged += OnHealthChanged;
        }

        private void OnDisable()
        {
            _ship.OnHealthChanged -= OnHealthChanged;
        }

        private void Awake()
        {
            _material = new Material(_viewConfig.MaterialPrefab);
            _renderer.material = _material;
        }

        private void OnHealthChanged(int current, int max)
        {
            if (current <= 0) 
                return;
            
            PlayHit();
            PlayDamage();
        }

        private void PlayHit()
        {
            if (_tween.IsActive())
                _tween.Kill();

            _tween = DOVirtual.Float(
                    HIT_ANIMATION_START, HIT_ANIMATION_END, _viewConfig.HitDuration,
                    p => _material.SetFloat(
                        _viewConfig.HitPropertyName,
                        _viewConfig.HitAnimationCurve.Evaluate(p)
                    )
                )
                .SetLink(_renderer.gameObject);
        }

        private void PlayDamage()
        {
            if (_damageSfx)
                _audioSource.PlayOneShot(_damageSfx);
        }
    }
}