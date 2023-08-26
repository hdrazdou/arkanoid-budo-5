using Arkanoid.Game.Blocks;
using Arkanoid.Utility;
using Unity.Mathematics;
using UnityEngine;

namespace Arkanoid.Game
{
    public class ExplosionHelper:SingletonMonoBehaviour<ExplosionHelper>
    {
        #region Public methods

        public void ExplodeBlocks(Vector3 center, float explosionRadius, LayerMask blockMask,
            GameObject vfxPrefab)
        {
            InstantiateVfx(vfxPrefab, center);

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

        #region Private methods

        private static void InstantiateVfx(GameObject vfxPrefab, Vector3 center)
        {
            if (vfxPrefab == null)
            {
                return;
            }

            Instantiate(vfxPrefab, center, quaternion.identity);
        }

        #endregion
    }
}