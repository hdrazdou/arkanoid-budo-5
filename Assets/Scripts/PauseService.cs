using System;
using UnityEngine;

namespace Arkanoid
{
    public class PauseService : SingletonMonoBehaviour<PauseService>
    {
        #region Events

        public event Action<bool> OnPauseStateChanged;

        #endregion

        #region Properties

        public bool IsPaused { get; private set; }

        #endregion

        #region Unity lifecycle

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                TogglePause();
            }
        }

        #endregion

        #region Public methods

        public void TogglePause()
        {
            IsPaused = !IsPaused;
            OnPauseStateChanged?.Invoke(IsPaused);
            Time.timeScale = IsPaused ? 0 : 1;
        }

        #endregion
    }
}