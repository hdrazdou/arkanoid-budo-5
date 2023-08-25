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
            SetScoresOnStart();

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
                Debug.Log($"GameService BallHitFloor OnGameOver?.Invoke _isGameOver {_isGameOver}");
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
            SetScoresOnStart();
        }

        public void StartGame()
        {
            Debug.Log("GameService StartGame");
            _isGameOver = false;
            SetScoresOnStart();
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
                // _isGameOver = false;
                ResetGame();
                Debug.Log($"GameService OnAllBlocksDestroyed _isGameOver {_isGameOver}");
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

        private void ResetGame()
        {
            SetScoresOnStart();
            Debug.Log($"GameService ResetGame _isGameOver {_isGameOver}");
        }

        private void SetScoresOnStart()
        {
            _cachedHp = _initHp;
            _totalScore = 0;
            Debug.Log($"GameService SetScoresOnStart Hp = {Hp}");
        }

        #endregion
    }
}