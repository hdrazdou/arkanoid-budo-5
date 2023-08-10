using UnityEngine;
using UnityEngine.UI;

namespace Arkanoid
{
    public class PauseScreen : MonoBehaviour
    {
        #region Variables

        [SerializeField] private GameObject _pauseScreenUi;
        [SerializeField] private Button _continueButton;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            _continueButton.onClick.AddListener(OnContinueButtonClicked);
            PauseService.Instance.OnPauseStateChanged += ChangePauseState;
            _pauseScreenUi.SetActive(false);
        }

        private void OnDestroy()
        {
            PauseService.Instance.OnPauseStateChanged -= ChangePauseState;
        }

        #endregion

        #region Private methods

        private void ChangePauseState(bool isPaused)
        {
            _pauseScreenUi.SetActive(isPaused);
        }

        private void OnContinueButtonClicked()
        {
            PauseService.Instance.TogglePause();
        }

        #endregion
    }
}