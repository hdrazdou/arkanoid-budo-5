using Arkanoid.Game.Services;
using UnityEngine;

namespace Arkanoid.Game
{
    public class Ball : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Transform _platformTransform;
        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private float _initialSpeed = 10;
        [SerializeField] private Vector2 _xLimitation;
        [SerializeField] private Vector2 _yLimitation;
        [SerializeField] private float _currentSpeed;
        private CircleCollider2D _collider;
        private bool _isStarted;

        private Vector3 _offset;
        private float _scale;

        #endregion

        #region Unity lifecycle

        private void Start()
        {

            _collider = GetComponent<CircleCollider2D>();

            _offset = transform.position - _platformTransform.position;

            PerformStartActions();
        }

        private void Update()
        {
            if (_isStarted)
            {
                return;
            }

            MoveWithPlatform();

            if (Input.GetMouseButtonDown(0))
            {
                StartTheBall();
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;

            if (!_isStarted)
            {
                Gizmos.DrawLine(transform.position, transform.position + (Vector3)GetRandomStartVelocity());
            }
            else
            {
                Gizmos.DrawLine(transform.position, transform.position + (Vector3)_rb.velocity);
            }
        }

        #endregion

        #region Public methods

        public void ChangeBallSizeByScale(float scale)
        {
            Vector3 ballScale = transform.localScale;

            ballScale.x *= scale;
            ballScale.x = Mathf.Clamp(ballScale.x, 0.5f, 5);

            ballScale.y = ballScale.x;

            transform.localScale = ballScale;

            ChangeOffsetByScale(scale);
        }

        public void ChangeBallSpeed(float speedMultiplier)
        {
            _currentSpeed *= speedMultiplier;

            if (_currentSpeed < 0.5f || _currentSpeed > 50)
            {
                speedMultiplier = AdjustSpeedMultiplier(speedMultiplier);
                _currentSpeed *= speedMultiplier;
            }

            _rb.velocity *= speedMultiplier;
        }

        public void ResetBall()
        {
            MoveWithPlatform();
            PerformStartActions();
        }

        #endregion

        #region Private methods

        private float AdjustSpeedMultiplier(float speedMultiplier)
        {
            if (_currentSpeed > 50)
            {
                speedMultiplier = 50 / _currentSpeed * speedMultiplier;
            }

            if (_currentSpeed < 0.5f)
            {
                speedMultiplier = 0.5f / _currentSpeed * speedMultiplier;
            }

            return speedMultiplier;
        }

        private void ChangeOffsetByScale(float scale)
        {
            float newRadius = GetRadius();
            float oldRadius = newRadius / scale;

            float offsetShift = (newRadius - oldRadius) * transform.localScale.x;

            _offset.y += offsetShift;
        }

        private float GetRadius()
        {
            float radius = _collider.radius;
            return radius;
        }

        private Vector2 GetRandomStartVelocity()
        {
            float x = Random.Range(_xLimitation.x, _xLimitation.y);
            float y = Random.Range(_yLimitation.x, _yLimitation.y);

            return new Vector2(x, y).normalized * _initialSpeed;
        }

        private void MoveWithPlatform()
        {
            Vector3 platformPosition = _platformTransform.position;
            transform.position = platformPosition + _offset;
        }

        private void PerformStartActions()
        {
            _isStarted = false;
            
            _currentSpeed = _initialSpeed;

            if (GameService.Instance.NeedAutoPlay)
            {
                StartTheBall();
            }
        }

        private void StartTheBall()
        {
            _isStarted = true;
            _rb.velocity = GetRandomStartVelocity();
        }

        #endregion
    }
}