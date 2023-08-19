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

            Ball ball = FindObjectOfType<Ball>();
            ball.ChangeBallSpeed(_speed);
        }

        #endregion
    }
}