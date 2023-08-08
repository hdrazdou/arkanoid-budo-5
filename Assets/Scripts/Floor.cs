using System;
using UnityEngine;

namespace Arkanoid
{
    public class Floor : SingletonMonoBehaviour<Floor>
    {
        #region Events

        public event Action OnFloorHit;

        #endregion

        #region Unity lifecycle

        private void OnCollisionEnter2D(Collision2D other)
        {
            OnFloorHit?.Invoke();
        }

        #endregion
    }
}