using Arkanoid.Game.Services;
using UnityEngine;

namespace Arkanoid.Game.PickUps
{
    public class ChangeBallSizePickup : PickUp
    {
        #region Variables

        [SerializeField] private float _scale = 1;

        #endregion

        #region Protected methods

        protected override void PerformActions()
        {
            base.PerformActions();

            foreach (Ball ball in LevelService.Instance.Balls)
            {
                ball.ChangeBallSizeByScale(_scale);
            }
        }

        #endregion
    }
}