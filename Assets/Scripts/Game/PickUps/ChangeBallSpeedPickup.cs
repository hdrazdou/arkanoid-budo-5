using Arkanoid.Game.Services;
using UnityEngine;

namespace Arkanoid.Game.PickUps
{
    public class ChangeBallSpeedPickup : PickUp
    {
        #region Variables

        [SerializeField] private float _speed;

        #endregion

        #region Protected methods

        protected override void PerformActions()
        {
            base.PerformActions();

            foreach (Ball ball in LevelService.Instance.Balls)
            {
                ball.ChangeBallSpeed(_speed);
            }
        }

        #endregion
    }
}