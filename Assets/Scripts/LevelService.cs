using System;
using UnityEngine;

namespace Arkanoid
{
    public class LevelService : SingletonMonoBehaviour<LevelService>
    {
        #region Events

        public event Action OnAllBlocksDestroyed;

        #endregion

        #region Unity lifecycle

        private void Update()
        {
            Block[] blocks = GetAllAliveBlocks();
            if (blocks.Length == 0)
            {
                OnAllBlocksDestroyed?.Invoke();
            }
        }

        #endregion

        #region Private methods

        private Block[] GetAllAliveBlocks()
        {
            return FindObjectsOfType<Block>();
        }

        #endregion
    }
}