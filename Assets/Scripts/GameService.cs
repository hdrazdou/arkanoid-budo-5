using System;
using UnityEngine.SceneManagement;

namespace Arkanoid
{
    public class GameService : SingletonMonoBehaviour<GameService>
    {
        #region Events

        public event Action<int> OnGameOver;

        public event Action<int> OnHpChanged;

        public event Action<int> OnScoreChanged;

        #endregion

        #region Properties

        public int Hp { get; private set; } = 3;

        public int TotalScore { get; private set; }

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            LevelService.Instance.OnAllBlocksDestroyed += OnAllBlocksDestroyed;
            Floor.Instance.OnFloorHit += OnFloorHit;
        }

        private void OnDestroy()
        {
            LevelService.Instance.OnAllBlocksDestroyed -= OnAllBlocksDestroyed;
            Floor.Instance.OnFloorHit -= OnFloorHit;
        }

        #endregion

        #region Public methods

        public void AddScore(int score)
        {
            TotalScore += score;
            OnScoreChanged?.Invoke(TotalScore);
        }

        #endregion

        #region Private methods

        private void LoadNextLevel()
        {
            SceneLoader.Instance.LoadNextScene();
        }

        private void OnAllBlocksDestroyed()
        {
            LoadNextLevel();
        }

        private void OnFloorHit()
        {
            Hp--;
            OnHpChanged?.Invoke(Hp);
            ResetBall();

            if (Hp <= 0)
            {
                OnGameOver?.Invoke(TotalScore);
                // ReloadGame();
            }
        }

        private void ReloadGame()
        {
            ResetScores();
            SceneManager.LoadScene(0);
        }

        private static void ResetBall()
        {
            Ball ball = FindObjectOfType<Ball>();
            ball.ResetBall();
        }

        private void ResetScores()
        {
            // OnHpChanged?.Invoke(3);
            // OnScoreChanged?.Invoke(0);
            Hp = 3;
            TotalScore = 0;
        }

        #endregion
    }
}