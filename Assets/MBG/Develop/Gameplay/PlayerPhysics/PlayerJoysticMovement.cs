using UnityEngine;

namespace Assets.MBG.Develop
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerJoystickMovement : MonoBehaviour
    {
        [SerializeField] private bl_Joystick Joystick;  // Reference to the Joystick component
        [SerializeField] private float Speed = 1f;  // Movement speed
        [SerializeField] private float _ventResistance = 0.004f;  // Resistance for smooth deceleration

        private Vector3 _direction;  // Movement direction
        private Vector3 _externalForce;  // Any additional external forces
        private Rigidbody _rigidbody;

        private void Update()
        {
            // Get joystick input
            float horizontal = Joystick.Horizontal;
            float vertical = Joystick.Vertical;

            // Keyboard input (A and D keys)
            if (Input.GetKey(KeyCode.A))
                horizontal = -1;
            else if (Input.GetKey(KeyCode.D))
                horizontal = 1;

            _direction = new Vector3(horizontal, 0, vertical);
            if (Mathf.Abs(horizontal) < 0.1f && Mathf.Abs(vertical) < 0.1f)
            {
                _direction = Vector3.zero;
            }
        }

        private void FixedUpdate()
        {
            Vector3 movement = Vector3.zero;

            if (_direction != Vector3.zero)
            {
                movement = _direction.normalized * Speed * Time.fixedDeltaTime;
            }

            movement += _externalForce;
            _rigidbody.MovePosition(transform.position + movement);
            _externalForce = Vector3.Lerp(_externalForce, Vector3.zero, _ventResistance);
        }

        public void ApplyForce(Vector3 force)
        {
            _externalForce += force;
        }

        public void ClearExternalForce()
        {
            _externalForce = Vector3.zero;
        }

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }
    }
}
