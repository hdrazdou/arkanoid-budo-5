using Arkanoid.Game.Services;
using UnityEngine;

namespace Arkanoid.Game.PickUps
{
    public class ExplosionPickUp : PickUp
    {
        #region Variables

        [SerializeField] private float _explosionRadius = 1f;
        [SerializeField] private LayerMask _blockMask;
        [SerializeField] private GameObject _vfxPrefab;
        

        #endregion

        #region Protected methods

        protected override void PerformActions()
        {
            base.PerformActions();

            foreach (Ball ball in LevelService.Instance.Balls)
            {
                ball.MakeExplosive(_explosionRadius, _blockMask, _vfxPrefab);
            }
        }

        #endregion
    }
}