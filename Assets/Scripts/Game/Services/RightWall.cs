using UnityEngine;

namespace Arkanoid.Game.Services
{
    public class RightWall : MonoBehaviour
    {
        #region Variables

        private float _mainCameraWidth;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            float cameraSize = Camera.main.orthographicSize;
            _mainCameraWidth = Camera.main.aspect * cameraSize;

            Vector3 transformPosition = transform.position;
            transformPosition.x = _mainCameraWidth;
            transform.position = transformPosition;
        }

        #endregion
    }
}