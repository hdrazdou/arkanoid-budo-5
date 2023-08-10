using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Arkanoid
{
    public class GameScreen : MonoBehaviour
    {
        #region Variables

        [SerializeField] private TMP_Text _scoreLabel;
        [SerializeField] private TMP_Text _hpLabel;
        [SerializeField] private GameObject _heartPrefab;
        [SerializeField] private Transform _heartParentTransform;
        private readonly List<GameObject> _hpHearts = new();


        #endregion

        #region Unity lifecycle

        private void Start()
        {
            CreateHearts();
            
            GameService.Instance.OnScoreChanged += UpdateScore;
            GameService.Instance.OnHpChanged += UpdateHp;

            UpdateScore(GameService.Instance.TotalScore);
            UpdateHp(GameService.Instance.Hp);
        }

        private void CreateHearts()
        {
            for (int i = 0; i < GameService.Instance.Hp; i++)
            {
                _hpHearts.Add(Instantiate(_heartPrefab, _heartParentTransform));
            }
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

            for (int i = 0; i < _hpHearts.Count; i++)
            {
                _hpHearts[i].gameObject.SetActive(hp > i);
            }
        }

        private void UpdateScore(int score)
        {
            _scoreLabel.text = $"Score: {score}";
        }

        #endregion
    }
}