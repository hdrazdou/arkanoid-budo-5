using System;

namespace Arkanoid
{
    public class GameService : SingletonMonoBehaviour<GameService>
    {
        #region Events

        public event Action<int> OnScoreChanged;

        #endregion

        #region Properties

        public int TotalScore { get; private set; }

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            LevelService.Instance.OnAllBlocksDestroyed += OnAllBlocksDestroyed;
        }

        private void OnDestroy()
        {
            LevelService.Instance.OnAllBlocksDestroyed -= OnAllBlocksDestroyed;
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

        private void UpdateScore(int score)
        {
            TotalScore += score;
        }

        #endregion
    }
}