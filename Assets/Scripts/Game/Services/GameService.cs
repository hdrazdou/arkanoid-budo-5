using System;
using System.Collections.Generic;
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

        [Header("Settings")]
        [SerializeField] private int _hp;
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
            get => _hp;

            private set
            {
                bool NeedNotify = _hp != value;
                _hp = value;

                if (NeedNotify)
                {
                    OnHpChanged?.Invoke(_hp);
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
            SetHpOnStart();

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
            ResetScores();
        }

        public void StartGame()
        {
            ResetScores();
        }

        #endregion

        #region Private methods

        private static void DestroyClonedBalls()
        {
            List<Ball> balls = LevelService.Instance.Balls;
            
            Debug.Log($"GameService ResetBall DestroyClonedBalls {LevelService.Instance.Balls}");

            for (int i = 1; i < balls.Count; i++)
            {
                Destroy(balls[i]);
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
                _isGameOver = false;
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
            if (LevelService.Instance.Balls.Count > 1)
            {
                DestroyClonedBalls();
            }

            Ball ball = FindObjectOfType<Ball>();
            ball.ResetBall();
        }

        private void ResetScores()
        {
            Hp = 3;
            TotalScore = 0;
            // _isGameOver = false;
        }

        private void SetHpOnStart()
        {
            Hp = _hp;
        }

        #endregion
    }
}