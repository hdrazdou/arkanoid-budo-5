using System;
using Arkanoid.Game.Services;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Arkanoid.Game
{
    public class Ball : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Transform _platformTransform;
        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private float _speed = 10;
        [SerializeField] private Vector2 _xLimitation;
        [SerializeField] private Vector2 _yLimitation;
        [SerializeField] private GameObject _ballTrail;
        private LayerMask _blockMask;
        private CircleCollider2D _collider;
        private float _explosionRadius;
        private bool _isExplosive;
        private bool _isStarted;

        private Vector3 _offset;
        private float _scale;

        #endregion

        #region Events

        public static event Action<Ball> OnCreated;
        public static event Action<Ball> OnDestroyed;

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            _collider = GetComponent<CircleCollider2D>();

            _offset = transform.position - _platformTransform.position;

            PerformStartActions();
        }

        private void Start()
        {
            OnCreated?.Invoke(this);

            if (GameService.Instance.NeedAutoPlay)
            {
                StartTheBall();
            }
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

        private void OnDestroy()
        {
            OnDestroyed?.Invoke(this);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            bool isPlatform = other.gameObject.TryGetComponent(out Platform platform);

            if (isPlatform)
            {
                return;
            }

            if (_isExplosive)
            {
                ExplosionHelper.ExplodeBlocks(transform.position, _explosionRadius, _blockMask);
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;

            if (!_isStarted)
            {
                Vector2 firstVector = new Vector2(_xLimitation.x, _yLimitation.x).normalized * _speed;
                Gizmos.DrawLine(transform.position, transform.position + (Vector3)firstVector);

                Vector2 secondVector = new Vector2(_xLimitation.y, _yLimitation.y).normalized * _speed;
                Gizmos.DrawLine(transform.position, transform.position + (Vector3)secondVector);
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

            if (ballScale != transform.localScale)
            {
                transform.localScale = ballScale;
                ChangeOffsetByScale(scale);
            }
        }

        public void ChangeBallSpeed(float speedMultiplier)
        {
            _rb.velocity *= speedMultiplier;

            AdjustBallSpeed();
        }

        public Ball Clone()
        {
            Ball clone = Instantiate(this, transform.position, Quaternion.identity);
            clone._isStarted = _isStarted;
            clone._offset = _offset;
            clone._rb.velocity = _rb.velocity;
            if (_isExplosive)
            {
                clone.MakeExplosive(_explosionRadius, _blockMask);
            }

            return clone;
        }

        public void MakeExplosive(float explosionRadius, LayerMask blockMask)
        {
            _isExplosive = true;
            _explosionRadius = explosionRadius;
            _blockMask = blockMask;
            EnableTrail();
        }

        public void RandomizeDirection()
        {
            Vector2 randomDirection = Random.insideUnitCircle.normalized;
            float currentSpeed = _rb.velocity.magnitude;
            _rb.velocity = randomDirection * currentSpeed;
        }

        public void ResetBall()
        {
            MoveWithPlatform();
            PerformStartActions();
        }

        #endregion

        #region Private methods

        private void AdjustBallSpeed()
        {
            float maxSpeed = 40;
            float minSpeed = 3;

            if (_rb.velocity.magnitude > maxSpeed)
            {
                _rb.velocity = _rb.velocity.normalized * maxSpeed;
            }

            if (_rb.velocity.magnitude < minSpeed)
            {
                _rb.velocity = _rb.velocity.normalized * minSpeed;
            }
        }

        private void ChangeOffsetByScale(float scale)
        {
            float newRadius = GetRadius();
            float oldRadius = newRadius / scale;

            float offsetShift = (newRadius - oldRadius) * transform.localScale.x;

            _offset.y += offsetShift;
        }

        private void DisableTrail()
        {
            _ballTrail.SetActive(false);
        }

        private void EnableTrail()
        {
            _ballTrail.SetActive(true);
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

            return new Vector2(x, y).normalized * _speed;
        }

        private void MoveWithPlatform()
        {
            Vector3 platformPosition = _platformTransform.position;
            transform.position = platformPosition + _offset;
        }

        private void PerformStartActions()
        {
            _isStarted = false;
            _isExplosive = false;
            DisableTrail();
        }

        private void StartTheBall()
        {
            _isStarted = true;
            _rb.velocity = GetRandomStartVelocity();
        }

        #endregion
    }
}