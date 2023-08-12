using Arkanoid.Game.Services;
using Arkanoid.Utility;
using UnityEngine;

namespace Arkanoid.Game
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