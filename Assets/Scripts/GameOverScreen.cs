using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Arkanoid
{
    public class GameOverScreen : MonoBehaviour
    {
        #region Variables

        [SerializeField] private GameObject _gameOverUi;

        [SerializeField] private TMP_Text _gameOverScoreLabel;
        [SerializeField] private Button _restartButton;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            _gameOverUi.SetActive(false);
            GameService.Instance.OnGameOver += ShowGameOver;
            _restartButton.onClick.AddListener(OnRestartButtonClicked);
        }

        private void OnRestartButtonClicked()
        {
            GameService.Instance.ReloadGame();
        }

        private void OnDestroy()
        {
            GameService.Instance.OnGameOver -= ShowGameOver;
        }

        #endregion

        #region Private methods

        private void ShowGameOver(int score)
        {
            _gameOverScoreLabel.text = $"Your Score: {score}";
            _gameOverUi.SetActive(true);
        }

        #endregion
    }
}