using UnityEngine;

namespace Arkanoid
{
    public class Block : MonoBehaviour
    {
        #region Variables

        [SerializeField] private int _hp = 1;
        [SerializeField] private BlockStatesContainer BlockSprites;

        private bool _areStatesAvailable;
        private int _blockStateIndex;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            DestroyIfZeroHp();

            _areStatesAvailable = BlockSprites.BlockStatesSprites.Length > 0;

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
                Destroy(gameObject);
            }
        }

        private void SetBlockStates()
        {
            if (_blockStateIndex == BlockSprites.BlockStatesSprites.Length)
            {
                return;
            }

            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = BlockSprites.BlockStatesSprites[_blockStateIndex];
        }

        #endregion
    }
}