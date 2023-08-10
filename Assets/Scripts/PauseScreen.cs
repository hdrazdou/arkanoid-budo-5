using UnityEngine;

namespace Arkanoid
{
    public class PauseScreen : MonoBehaviour
    {
        #region Variables

        [SerializeField] private GameObject _pauseImage;
        [SerializeField] private GameObject _pauseLabel;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            PauseService.Instance.OnPauseStateChanged += ChangePauseState;
            _pauseImage.SetActive(false);
        }

        private void OnDestroy()
        {
            PauseService.Instance.OnPauseStateChanged -= ChangePauseState;
        }

        #endregion

        #region Private methods

        private void ChangePauseState(bool isPaused)
        {
            _pauseImage.SetActive(isPaused);
            _pauseLabel.SetActive(isPaused);
        }

        #endregion
    }
}