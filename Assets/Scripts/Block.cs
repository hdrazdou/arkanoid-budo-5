using UnityEngine;

namespace Arkanoid
{
    public class Block : MonoBehaviour
    {
        #region Variables

        [SerializeField] private int _hp = 1;
        [SerializeField] private BlockStatesContainer _blockStatesContainer;
        [SerializeField] private int _score;
        [SerializeField] private SpriteRenderer _spriteRenderer;

        private bool _areStatesAvailable;
        private int _blockStateIndex;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            DestroyIfZeroHp();

            _areStatesAvailable = _blockStatesContainer.BlockStatesSprites.Length > 0;

            if (_areStatesAvailable)
            {
                _blockStateIndex = 0;
                SetBlockStates();
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
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

        private void SetBlockStates()
        {
            if (_blockStateIndex == _blockStatesContainer.BlockStatesSprites.Length)
            {
                return;
            }

            _spriteRenderer.sprite = _blockStatesContainer.BlockStatesSprites[_blockStateIndex];
        }

        #endregion
    }
}