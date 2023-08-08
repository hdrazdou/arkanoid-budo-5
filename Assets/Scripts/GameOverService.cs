using System;
using TMPro;
using UnityEngine;

namespace Arkanoid
{
    public class GameOverService : MonoBehaviour
    {
        [SerializeField] private TMP_Text _gameOverScoreLabel;

        private void Start()
        {
            gameObject.SetActive(false);
            GameService.Instance.OnGameOver += ShowGameOver;
        }

        private void Update()
        {
            GameService.Instance.OnGameOver -= ShowGameOver;
        }

        private void ShowGameOver(int score)
        {
            _gameOverScoreLabel.text = $"Your Score: {score}";
            gameObject.SetActive(true);
        }
    }
}