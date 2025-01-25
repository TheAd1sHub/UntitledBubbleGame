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

        private Vector3 _direction;

        private Player _player;
        private Rigidbody _rigidbody;

#if TEST_IMPLEMENTATION
        private void FixedUpdate()
        {
            if (_direction != Vector3.zero)
                //_rigidbody.AddForce(_direction * _player.Speed);
                _rigidbody.linearVelocity = _direction * _player.Speed;
            else
                _rigidbody.linearVelocity = Vector3.Lerp(_rigidbody.linearVelocity, Vector3.zero, _player.Responsiveness * Time.fixedDeltaTime);
        }
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

        private void OnMovedHorizontally(Vector3 direction) => _direction = direction;
    }
    public interface IInputHandler
    {
        public event Action<Vector3> MovedHorizontally;
    }
}
