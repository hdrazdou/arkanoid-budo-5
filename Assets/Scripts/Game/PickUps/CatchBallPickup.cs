using Arkanoid.Game.Services;

namespace Arkanoid.Game.PickUps
{
    public class CatchBallPickup : PickUp
    {
        #region Protected methods

        protected override void PerformActions()
        {
            base.PerformActions();

            foreach (Ball ball in LevelService.Instance.Balls)
            {
                ball.ResetBall();
            }
        }

        #endregion
    }
}