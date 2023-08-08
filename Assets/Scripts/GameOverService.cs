using TMPro;
using UnityEngine;

namespace Arkanoid
{
    public class GameOverService : MonoBehaviour
    {
        #region Variables

        [SerializeField] private GameObject _gameOverImage;

        [SerializeField] private TMP_Text _gameOverScoreLabel;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            _gameOverImage.SetActive(false);
            GameService.Instance.OnGameOver += ShowGameOver;
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
            _gameOverImage.SetActive(true);
        }

        #endregion
    }
}