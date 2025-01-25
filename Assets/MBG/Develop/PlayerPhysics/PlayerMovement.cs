#define TEST_IMPLEMENTATION

using Assets.MBG.Develop.MarkerScripts;
using System;
using UnityEngine;

namespace Assets.MBG.Develop
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovement : MonoBehaviour, IInputHandler
    {
        public event Action<Vector3> MovedHorizontally;

        [SerializeField] private float _ventResistance;

        private Vector3 _direction;
        private Vector3 _externalForce;

        private Player _player;
        private Rigidbody _rigidbody;

        public void ApplyForce(Vector3 force)
        {
            _externalForce += force;
        }

        private void OnMovedHorizontally(Vector3 direction) => _direction = direction;

        private void FixedUpdate()
        {
            Vector3 movement = Vector3.up * _player.VerticalSpeed;

            if (_direction != Vector3.zero)
            {
                Vector3 targetHorizontalVelocity = _direction * _player.HorizontalSpeed;
                Vector3 currentHorizontalVelocity = new(_rigidbody.linearVelocity.x, 0, _rigidbody.linearVelocity.z);

                Vector3 newHorizontalVelocity = Vector3.Lerp(currentHorizontalVelocity, targetHorizontalVelocity, _player.Responsiveness * Time.fixedDeltaTime);

                movement += newHorizontalVelocity;
            }
            else
            {
                Vector3 horizontalVelocity = new(_rigidbody.linearVelocity.x, 0, _rigidbody.linearVelocity.z);

                horizontalVelocity = Vector3.Lerp(horizontalVelocity, Vector3.zero, _player.Responsiveness);

                movement += horizontalVelocity;
            }

            movement += _externalForce;

            _rigidbody.linearVelocity = movement;

            _externalForce = Vector3.Lerp(_externalForce, Vector3.zero, _ventResistance);

        }
#if TEST_IMPLEMENTATION
        private void Update()
        {
            if (Input.GetKey(KeyCode.A))
                _direction = Vector3.left;
            else if (Input.GetKey(KeyCode.D))
                _direction = Vector3.right;
            else
                _direction = Vector3.zero;
        }
#endif
        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _player = GetComponent<Player>();

            MovedHorizontally += OnMovedHorizontally;
        }

    }
    public interface IInputHandler
    {
        public event Action<Vector3> MovedHorizontally;
    }
}
