using UnityEngine;

namespace Arkanoid.Game.PickUps
{
    public class ChangeBallSizePickup : PickUp
    {
        [SerializeField] private float _scale = 1;

        protected override void PerformActions()
        {
            base.PerformActions();

            Ball ball = FindObjectOfType<Ball>();
            ball.ChangeBallSizeByScale(_scale);
        }
    }
}