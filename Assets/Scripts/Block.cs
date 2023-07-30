using UnityEngine;

namespace Arkanoid
{
    public class Block : MonoBehaviour
    {
        #region Variables

        [SerializeField] private int _hp = 1;
        [SerializeField] private BlockStatesContainer BlockSprites;
        [SerializeField] private int _blockPoints;
        [SerializeField] private GameScreen _gameScreen;

        private bool _areStatesAvailable;
        private int _blockStateIndex;
        private static int _totalScore;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            _totalScore = 0;

            DestroyIfZeroHp();

            _areStatesAvailable = BlockSprites.BlockStatesSprites.Length > 0;

            if (_areStatesAvailable)
            {
                _blockStateIndex = 0;
                SetBlockStates();
            }
        }

        private void OnDestroy()
        {
            _totalScore += _blockPoints;
            _gameScreen.UpdateScorePoints(_totalScore);
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