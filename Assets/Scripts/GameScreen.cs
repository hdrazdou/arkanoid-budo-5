using TMPro;
using UnityEngine;

namespace Arkanoid
{
    public class GameScreen : MonoBehaviour
    {
        #region Variables

        [SerializeField] private TMP_Text _scoreLabel;
        [SerializeField] private TMP_Text _hpLabel;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            GameService.Instance.OnScoreChanged += UpdateScore;
            GameService.Instance.OnHpChanged += UpdateHp;

            UpdateScore(GameService.Instance.TotalScore);
            UpdateHp(GameService.Instance.Hp);
        }

        private void OnDestroy()
        {
            GameService.Instance.OnScoreChanged -= UpdateScore;
            GameService.Instance.OnHpChanged -= UpdateHp;
        }

        #endregion

        #region Private methods

        private void UpdateHp(int hp)
        {
            _hpLabel.text = $"Lives: {hp}";
        }

        private void UpdateScore(int score)
        {
            _scoreLabel.text = $"Score: {score}";
        }

        #endregion
    }
}