using DG.Tweening;
using UnityEngine;

namespace Game.Presentations
{
    public sealed class ShipMaterialHitEffect
    {
        private Renderer _renderer;
        private ShipViewConfig _viewConfig;
        private Material _material;
        private Tweener _tween;
        
        private const float HIT_ANIMATION_START = 0f;
        private const float HIT_ANIMATION_END = 1f;

        public void Init(Renderer renderer, ShipViewConfig viewConfig)
        {
            if (renderer == null || viewConfig == null)
            {
                Debug.LogError("ShipMaterialHitEffect is null");
                return;
            }
            
            _renderer = renderer;
            _viewConfig = viewConfig;
            
            _material = new Material(_viewConfig.MaterialPrefab);
            _renderer.material = _material;
        }
        
        public void PlayHit()
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
    }
}