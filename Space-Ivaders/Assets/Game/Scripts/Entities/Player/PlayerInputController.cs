using UnityEngine;

namespace Game.Entities
{
    public sealed class PlayerInputController : MonoBehaviour
    {
        [SerializeField] private Ship _playerShip;
        
        private Vector2 _moveDirection;        

        private void Update()
        {
            GetInput();
        }

        private void GetInput()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                _playerShip.Attack(Vector3.up);
            
            float dx = Input.GetAxisRaw("Horizontal");
            float dy = Input.GetAxisRaw("Vertical");

            _moveDirection = new Vector2(dx, dy);

            if (_moveDirection != Vector2.zero)
                _playerShip.Move(_moveDirection);
        }
    }
}