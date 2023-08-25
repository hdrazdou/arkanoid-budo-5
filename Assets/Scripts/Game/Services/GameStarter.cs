using UnityEngine;

namespace Arkanoid.Game.Services
{
    public class GameStarter : MonoBehaviour
    {
        #region Unity lifecycle

        private void Start()
        {
            GameService.Instance.OnStartActions();
        }

        #endregion
    }
}