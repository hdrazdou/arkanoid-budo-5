namespace Arkanoid.Game.PickUps
{
    public class CatchBallPickup : PickUp
    {
        protected override void PerformActions()
        {
            base.PerformActions();

            Ball ball = FindObjectOfType<Ball>();
            ball.ResetBall();
        }
    }
}