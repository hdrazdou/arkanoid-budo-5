using System;
using Arkanoid.Game.Services;
using Arkanoid.Utility;
using UnityEngine;

namespace Arkanoid.Game.Blocks
{
    public class Block : MonoBehaviour
    {
        #region Variables

        [Header("Settings")]
        [SerializeField] private int _hp = 1;
        [SerializeField] private int _score;
        [SerializeField] private bool _isInvisible;

        [Header("Components")]
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private BlockStatesContainer _blockStatesContainer;

        private bool _areStatesAvailable;
        private int _blockStateIndex;

        #endregion

        #region Events

        public static event Action<Block> OnCreated;
        public static event Action<Block> OnDestroyed;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            OnCreated?.Invoke(this);

            DestroyIfZeroHp();

            HideIfInvisible();

            _areStatesAvailable = _blockStatesContainer.BlockStatesSprites.Length > 0;

            if (_areStatesAvailable)
            {
                _blockStateIndex = 0;
                SetBlockStates();
            }
        }

        private void OnDestroy()
        {
            OnDestroyed?.Invoke(this);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (_isInvisible)
            {
                _isInvisible = false;
                _spriteRenderer.SetAlpha(1);
                return;
            }

            _hp--;

            DestroyIfZeroHp();

            if (_areStatesAvailable)
            {
                _blockStateIndex++;
                SetBlockStates();
            }
        }

        #endregion

        #region Public methods

        public void ForceDestroy()
        {
            PerformDestroyActions();
        }

        #endregion

        #region Protected methods

        protected virtual void OnDestroyedActions() { }

        #endregion

        #region Private methods

        private void DestroyIfZeroHp()
        {
            if (_hp <= 0)
            {
                PerformDestroyActions();
            }
        }

        private void HideIfInvisible()
        {
            if (_isInvisible)
            {
                _spriteRenderer.SetAlpha(0);
            }
        }

        private void PerformDestroyActions()
        {
            GameService.Instance.ChangeScore(_score);
            Destroy(gameObject);
            PickUpService.Instance.CreatePickUp(transform.position);
            OnDestroyedActions();
        }

        private void SetBlockStates()
        {
            if (_blockStateIndex >= _blockStatesContainer.BlockStatesSprites.Length)
            {
                return;
            }

            _spriteRenderer.sprite = _blockStatesContainer.BlockStatesSprites[_blockStateIndex];
        }

        #endregion
    }
}