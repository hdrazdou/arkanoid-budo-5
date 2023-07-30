using TMPro;
using UnityEngine;

namespace Arkanoid
{
    public class GameScreen : MonoBehaviour
    {
        #region Variables

        [SerializeField] private TMP_Text _scoreLabel;

        #endregion

        #region Public methods

        public void UpdateScorePoints(int totalScore)
        {
            _scoreLabel.text = $"Score: {totalScore}";
        }

        #endregion
    }
}