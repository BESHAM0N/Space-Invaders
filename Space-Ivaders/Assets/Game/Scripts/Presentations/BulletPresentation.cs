using Game.Entities;
using UnityEngine;

namespace Game.Presentations
{
    public sealed class BulletPresentation : MonoBehaviour
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
        }

        private void OnDisable()
        {
            _bullet.OnInit -= ApplyTeamVisuals;
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

        public void ExplosionVFXPlay(Ship ship)
        {
            if (_bullet.TeamType == TeamType.Player && ship is EnemyShip ||
                _bullet.TeamType == TeamType.Enemy && ship is PlayerShip)
            {
                GameObject prefab = _configView.ExplosionVFX;
                Instantiate(prefab, _bullet.transform.position, prefab.transform.rotation);
            }
        }
    }
}