using System;

namespace Arkanoid
{
    public static class ScoreService
    {
        #region Events

        public static event Action<int> OnScoreChanged;

        #endregion

        #region Properties

        public static int Score { get; private set; }

        #endregion

        #region Public methods

        public static void AddScore(int score)
        {
            Score += score;
            OnScoreChanged?.Invoke(Score);
        }

        #endregion
    }
}