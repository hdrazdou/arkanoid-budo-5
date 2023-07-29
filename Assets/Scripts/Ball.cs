using UnityEngine;
using UnityEngine.Serialization;

namespace Arkanoid
{
    public class Ball : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Platform _platform;
        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private Vector2 _startVelocity;
        private Vector3 _offset;
        private bool _isStarted;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
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

        private void StartTheBall()
        {
            _isStarted = true;
            _rb.velocity = _startVelocity;
        }

        private void MoveWithPlatform()
        {
            Vector3 platformPosition = _platform.transform.position;
            transform.position = platformPosition + _offset;
        }

        #endregion
    }
}