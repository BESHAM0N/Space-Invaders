using UnityEngine;

namespace Game.Content
{
    public sealed class BulletView : MonoBehaviour
    {
        [SerializeField] private Bullet _bullet;
        [SerializeField] private BulletViewConfig _configView;

        [SerializeField] private GameObject _blueVFX;
        [SerializeField] private GameObject _redVFX;

        private const string DEFAULT_LAYER_NAME = "Default";
        private const string PLAYER_LAYER_NAME = "PlayerBullet";
        private const string ENEMY_LAYER_NAME = "EnemyBullet";

        private void OnEnable()
        {
            _bullet.OnInit += ApplyTeamVisuals;
            _bullet.OnTriggerEntered += OnBulletTriggerEntered;
        }

        private void OnDisable()
        {
            _bullet.OnInit -= ApplyTeamVisuals;
            _bullet.OnTriggerEntered -= OnBulletTriggerEntered;
        }

        private void ApplyTeamVisuals()
        {
            gameObject.layer = _bullet.TeamType switch
            {
                TeamType.None => LayerMask.NameToLayer(DEFAULT_LAYER_NAME),
                TeamType.Player => LayerMask.NameToLayer(PLAYER_LAYER_NAME),
                TeamType.Enemy => LayerMask.NameToLayer(ENEMY_LAYER_NAME),
                _ => LayerMask.NameToLayer(DEFAULT_LAYER_NAME)
            };

            if (_bullet.TeamType == TeamType.Player)
            {
                _blueVFX.SetActive(true);
                _redVFX.SetActive(false);
            }
            else
            {
                _blueVFX.SetActive(false);
                _redVFX.SetActive(true);
            }
        }
        
        private void OnBulletTriggerEntered(Bullet bullet, Collider2D other)
        {
            if (!other.TryGetComponent(out Ship ship))
                return;
            
            if (bullet.TeamType == TeamType.Player && ship.TeamType is TeamType.Enemy ||
                bullet.TeamType == TeamType.Enemy && ship.TeamType is TeamType.Player)
            {
                PlayExplosion(bullet.CurrentPosition);
            }
        }
        
        private void PlayExplosion(Vector3 position)
        {
            GameObject prefab = _configView.ExplosionVFX;
            Instantiate(prefab, position, prefab.transform.rotation);
        }
    }
}