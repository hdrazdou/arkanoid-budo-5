using UnityEngine;

namespace Arkanoid
{
    public class Ball : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Platform _platform;
        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private Vector2 _startVelocity;
        [SerializeField] private float _velocityMultiplier = 10;
        private bool _isStarted;
        private Vector3 _offset;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            SetRandomStartVelocity();

            _offset = transform.position - _platform.transform.position;
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

        #region Private methods

        private void MoveWithPlatform()
        {
            Vector3 platformPosition = _platform.transform.position;
            transform.position = platformPosition + _offset;
        }

        private void SetRandomStartVelocity()
        {
            float x = Random.Range(1f, 10f);
            float y = Random.Range(1f, 10f);

            _startVelocity = new Vector2(x, y).normalized * _velocityMultiplier;
        }

        private void StartTheBall()
        {
            _isStarted = true;
            _rb.velocity = _startVelocity;
        }

        #endregion
    }
}