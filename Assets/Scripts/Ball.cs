using UnityEngine;

namespace Arkanoid
{
    public class Ball : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Transform _platformTransform;
        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private float _speed = 10;
        [SerializeField] private Vector2 _xLimitation;
        [SerializeField] private Vector2 _yLimitation;
        private bool _isStarted;
        private Vector3 _offset;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            _offset = transform.position - _platformTransform.position;
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

        #endregion

        #region Public methods

        public void ResetBall()
        {
            _isStarted = false;
            MoveWithPlatform();
        }

        #endregion

        #region Private methods

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

        private void StartTheBall()
        {
            _isStarted = true;
            _rb.velocity = GetRandomStartVelocity();
        }

        #endregion
    }
}