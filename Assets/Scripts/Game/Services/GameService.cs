using System;
using Arkanoid.Infrastructure;
using Arkanoid.Utility;
using UnityEngine;

namespace Arkanoid.Game.Services
{
    public class GameService : SingletonMonoBehaviour<GameService>
    {
        #region Variables

        [Header("Auto-play")]
        [SerializeField] private bool _needAutoPlay;
        [SerializeField] private int _initHp;

        [Header("Settings")]
        private int _cachedHp;
        private bool _isGameOver;

        private int _totalScore;

        #endregion

        #region Events

        public event Action<int> OnGameOver;
        public event Action<int> OnGameWon;
        public event Action<int> OnHpChanged;
        public event Action<int> OnScoreChanged;

        #endregion

        #region Properties

        public int Hp
        {
            get => _cachedHp;

            private set
            {
                bool NeedNotify = _cachedHp != value;
                _cachedHp = value;

                if (NeedNotify)
                {
                    OnHpChanged?.Invoke(_cachedHp);
                }
            }
        }

        public bool NeedAutoPlay => _needAutoPlay;

        public int TotalScore
        {
            get => _totalScore;
            private set
            {
                bool NeedNotify = _totalScore != value;
                _totalScore = value;

                if (NeedNotify)
                {
                    OnScoreChanged?.Invoke(_totalScore);
                }
            }
        }

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            OnStartActions();

            LevelService.Instance.OnAllBlocksDestroyed += OnAllBlocksDestroyed;
        }

        private void OnDestroy()
        {
            LevelService.Instance.OnAllBlocksDestroyed -= OnAllBlocksDestroyed;
        }

        #endregion

        #region Public methods

        public void BallHitFloor()
        {
            Hp--;
            ResetBall();

            if (Hp <= 0)
            {
                OnGameOver?.Invoke(TotalScore);
                _isGameOver = true;
            }
        }

        public void ChangeHp(int hp)
        {
            Hp += hp;
        }

        public void ChangeScore(int score)
        {
            TotalScore = Mathf.Max(0, TotalScore + score); // чтоб TotalScore не мог быть ниже нуля
        }

        public void ReloadGame()
        {
            SceneLoader.Instance.LoadZeroScene();
            SetInitScores();
        }

        public void OnStartActions()
        {
            _isGameOver = false;
            SetInitScores();
        }

        #endregion

        #region Private methods

        private static void DestroyClonedBalls()
        {
            for (int i = 1; i < LevelService.Instance.Balls.Count; i++)
            {
                Destroy(LevelService.Instance.Balls[i].gameObject);
            }
        }

        private void LoadNextLevel()
        {
            SceneLoader.Instance.LoadNextScene();
        }

        private void OnAllBlocksDestroyed()
        {
            if (_isGameOver)
            {
                SetInitScores();
                return;
            }

            if (SceneLoader.Instance.IsLastLevel())
            {
                OnGameWon?.Invoke(TotalScore);
                return;
            }

            LoadNextLevel();
        }

        private static void ResetBall()
        {
            foreach (Ball ball in LevelService.Instance.Balls)
            {
                ball.ResetBall();
            }

            if (LevelService.Instance.Balls.Count > 1)
            {
                DestroyClonedBalls();
            }
        }

        private void SetInitScores()
        {
            _cachedHp = _initHp;
            _totalScore = 0;
        }

        #endregion
    }
}