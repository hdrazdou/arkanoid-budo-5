using Arkanoid.Game.Services;
using UnityEngine;

namespace Arkanoid.Game.Blocks
{
    public class ExplosiveBlock : Block
    {
        #region Variables

        [Header(nameof(ExplosiveBlock))]
        [SerializeField] private float _explosiveRadius = 1f;
        [SerializeField] private LayerMask _blockMask;

        #endregion

        #region Unity lifecycle

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _explosiveRadius);
        }

        #endregion

        #region Protected methods

        protected override void OnDestroyedActions()
        {
            base.OnDestroyedActions();

            LevelService.Instance.SetBlockMask(_blockMask);
            LevelService.Instance.ExplodeBlock(transform, _explosiveRadius);
        }

        #endregion
    }
}