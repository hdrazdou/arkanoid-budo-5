using Arkanoid.Game.Services;
using UnityEngine;

namespace Arkanoid.Game.PickUps
{
    public class CloneBallPickup : PickUp
    {
        #region Variables

        [SerializeField] private int _clonesCount = 2;

        #endregion

        #region Protected methods

        protected override void PerformActions()
        {
            base.PerformActions();
            
            foreach (Ball ball in LevelService.Instance.Balls)
            {
                for (int i = 0; i < _clonesCount; i++)
                {
                    Ball clone = ball.Clone();
                    clone.RandomizeDirection();
                }
            }
        }

        #endregion
    }
}