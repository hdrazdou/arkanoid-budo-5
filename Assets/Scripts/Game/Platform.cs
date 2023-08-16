using Arkanoid.Game.Services;
using UnityEngine;

namespace Arkanoid.Game
{
    public class Platform : MonoBehaviour
    {
        #region Unity lifecycle

        private void Update()
        {
            if (PauseService.Instance.IsPaused)
            {
                return;
            }

            if (GameService.Instance.NeedAutoPlay)
            {
                MoveWithBall();
            }
            else
            {
                MoveWithMouse();
            }
        }

        #endregion

        #region Public methods

        public void ChangePlatformWidthByScale(float scale)
        {
            Vector3 platformScale = transform.localScale;
            
            platformScale.x *= scale;
            platformScale.x = Mathf.Clamp(platformScale.x, 0.5f, 5);
            
            transform.localScale = platformScale;
        }

        #endregion

        #region Private methods

        private void MoveWithBall()
        {
            Vector3 ballPosition = FindObjectOfType<Ball>().transform.position;

            SetPosition(ballPosition);
        }

        private void MoveWithMouse()
        {
            Vector3 mousePosition = Input.mousePosition;
            Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

            SetPosition(worldMousePosition);
        }

        private void SetPosition(Vector3 worldPosition)
        {
            Vector3 currentPosition = transform.position;
            currentPosition.x = worldPosition.x;
            transform.position = currentPosition;
        }

        #endregion
    }
}