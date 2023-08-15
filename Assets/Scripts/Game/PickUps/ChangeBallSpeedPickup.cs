using UnityEngine;

namespace Arkanoid.Game.PickUps
{
    public class ChangeBallSpeedPickup : PickUp
    {
        [SerializeField] private float _speed;
        
        protected override void PerformActions()
        {
            base.PerformActions();

            Ball ball = FindObjectOfType<Ball>();
            ball.ChangeBallSpeed(_speed);
        }
    }
}