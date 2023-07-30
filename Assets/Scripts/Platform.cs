using UnityEngine;

namespace Arkanoid
{
    public class Platform : MonoBehaviour
    {
        #region Unity lifecycle

        private void Update()
        {
            MoveWithMouse();
        }

        #endregion

        #region Private methods

        private void MoveWithMouse()
        {
            Vector3 mousePosition = Input.mousePosition;
            Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            Vector3 currentPosition = transform.position;
            currentPosition.x = worldMousePosition.x;
            transform.position = currentPosition;
        }

        #endregion
    }
}