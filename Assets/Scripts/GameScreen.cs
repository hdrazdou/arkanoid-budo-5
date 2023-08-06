using TMPro;
using UnityEngine;

namespace Arkanoid
{
    public class GameScreen : MonoBehaviour
    {
        #region Variables

        [SerializeField] private TMP_Text _scoreLabel;

        private GameService _gameService;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            GameService.Instance.OnScoreChanged += UpdateScore;
            
            UpdateScore(GameService.Instance.TotalScore);
        }

        private void OnDestroy()
        {
            GameService.Instance.OnScoreChanged -= UpdateScore;
        }

        #endregion

        #region Public methods

        public void UpdateScore(int score)
        {
            _scoreLabel.text = $"Score: {score}";
        }

        #endregion
    }
}