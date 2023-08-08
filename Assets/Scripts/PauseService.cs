using UnityEngine;

namespace Arkanoid
{
    public class PauseService : SingletonMonoBehaviour<PauseService>
    {
        #region Variables

        [SerializeField] private GameObject _pauseImage;

        private bool _isPaused;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            _pauseImage.SetActive(false);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                TogglePause();
            }
        }

        #endregion

        #region Private methods

        private void TogglePause()
        {
            _isPaused = !_isPaused;
            Time.timeScale = _isPaused ? 0 : 1;

            _pauseImage.SetActive(_isPaused);
        }

        #endregion
    }
}