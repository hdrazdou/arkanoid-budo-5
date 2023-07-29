using System;
using UnityEngine;

namespace Arkanoid
{
    public class Platform : MonoBehaviour
    {
        private void Update()
        {
            MoveWithMouse();
        }

        private void MoveWithMouse()
        {
            Vector3 mousePosition = Input.mousePosition;
            Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            Vector3 currentPosition = transform.position;
            currentPosition.x = worldMousePosition.x;
            transform.position = currentPosition;
        }
    }
}