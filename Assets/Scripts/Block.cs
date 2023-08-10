using UnityEngine;

namespace Arkanoid
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

        #region Unity lifecycle

        private void Start()
        {
            DestroyIfZeroHp();

            HideIfInvisible();

            _areStatesAvailable = _blockStatesContainer.BlockStatesSprites.Length > 0;

            if (_areStatesAvailable)
            {
                _blockStateIndex = 0;
                SetBlockStates();
            }
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

        #region Private methods

        private void DestroyIfZeroHp()
        {
            if (_hp <= 0)
            {
                GameService.Instance.AddScore(_score);

                Destroy(gameObject);
            }
        }

        private void HideIfInvisible()
        {
            if (_isInvisible)
            {
                _spriteRenderer.SetAlpha(0);
            }
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