using UnityEngine;

namespace Assets.MBG.Develop.Gameplay.BaseBehaviours
{
    public sealed class Swinging : MonoBehaviour
    {
        [SerializeField, Min(0f)] private float _swingingSpeed = 5f;
        [SerializeField] private Vector3 _swingingStep = Vector3.up * 0.1f;
        [SerializeField, Min(0f)] private Vector3 _maxSwingingAmount = Vector3.up * 10f;

        private Vector3 _currentSwinging = Vector3.zero;
        private Direction _currentDirection = Direction.Up;

        private void Update()
        {
            if (Mathf.Abs(_currentSwinging.x) >= Mathf.Abs(_maxSwingingAmount.x) && _maxSwingingAmount.x != 0
                || Mathf.Abs(_currentSwinging.y) >= Mathf.Abs(_maxSwingingAmount.y) && _maxSwingingAmount.y != 0
                || Mathf.Abs(_currentSwinging.z) >= Mathf.Abs(_maxSwingingAmount.z) && _maxSwingingAmount.z != 0)
            {
                _currentDirection = (Direction)(-(int)_currentDirection);
                _currentSwinging = Vector3.zero;
                return;
            }

            Vector3 swingStep = _swingingStep * (_swingingSpeed * (int)_currentDirection) * Time.deltaTime;

            transform.Rotate(swingStep);
            _currentSwinging += swingStep;
        }

        private enum Direction { Up = 1, Down = -1 }
    }
}