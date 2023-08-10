using UnityEngine;

namespace Arkanoid
{
    public class Floor : SingletonMonoBehaviour<Floor>
    {
        #region Unity lifecycle

        private void OnCollisionEnter2D(Collision2D other)
        {
            GameService.Instance.OnFloorHit();
        }

        #endregion
    }
}