using TMPro;
using UnityEngine;

namespace Arkanoid
{
    public class GameScreen : MonoBehaviour
    {
        #region Variables

        [SerializeField] private TMP_Text _scoreLabel;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            ScoreService.OnScoreChanged += UpdateScorePoints;
        }

        private void OnDisable()
        {
            ScoreService.OnScoreChanged -= UpdateScorePoints;
        }

        #endregion

        #region Public methods

        public void UpdateScorePoints(int score)
        {
            _scoreLabel.text = $"Score: {score}";
        }

        #endregion
    }
}