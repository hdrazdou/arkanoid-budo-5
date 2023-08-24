using Arkanoid.Game.Services;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Arkanoid.UI
{
    public class GameWonScreen : MonoBehaviour
    {
        #region Variables

        [SerializeField] private GameObject _gameWonUi;
        [SerializeField] private TMP_Text _gameWonScoreLabel;
        [SerializeField] private Button _restartButton;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            _gameWonUi.SetActive(false);
            _restartButton.onClick.AddListener(OnRestartButtonClicked);
            GameService.Instance.OnGameWon += OnGameWon;
        }

        private void OnDestroy()
        {
            GameService.Instance.OnGameWon -= OnGameWon;
        }

        #endregion

        #region Private methods

        private void OnGameWon(int score)
        {
            _gameWonScoreLabel.text = $"Your Score: {score}";
            _gameWonUi.SetActive(true);
        }

        private void OnRestartButtonClicked()
        {
            GameService.Instance.ReloadGame();
        }

        #endregion
    }
}