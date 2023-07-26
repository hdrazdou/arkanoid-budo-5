using System;
using UnityEngine;

namespace Arkanoid
{
    public class Ball : MonoBehaviour
    {
        public Rigidbody2D Rb;
        public Vector2 StartDirection;

        private void Start()
        {
            Rb.velocity = StartDirection;
        }
    }
}