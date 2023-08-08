using TMPro;
using UnityEngine;

namespace Arkanoid
{
    public class GameOverService : MonoBehaviour
    {
        #region Variables

        [SerializeField] private TMP_Text _gameOverScoreLabel;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            gameObject.SetActive(false);
            GameService.Instance.OnGameOver += ShowGameOver;
        }

        private void Update()
        {
            GameService.Instance.OnGameOver -= ShowGameOver;
        }

        #endregion

        #region Private methods

        private void ShowGameOver(int score)
        {
            _gameOverScoreLabel.text = $"Your Score: {score}";
            gameObject.SetActive(true);
        }

        #endregion
    }
}