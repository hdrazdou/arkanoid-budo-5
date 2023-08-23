using Arkanoid.Game.Blocks;
using UnityEngine;

namespace Arkanoid.Game
{
    public static class ExplosionHelper
    {
        #region Public methods

        public static void ExplodeBlocks(Vector3 center, float explosionRadius, LayerMask blockMask)
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(center, explosionRadius, blockMask);

            foreach (Collider2D collider in colliders)
            {
                if (collider.TryGetComponent(out Block block))
                {
                    block.ForceDestroy();
                }
            }
        }

        #endregion
    }
}