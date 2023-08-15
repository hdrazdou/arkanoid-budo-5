using UnityEngine;

namespace Arkanoid.Game.PickUps
{
    public class ChangePlatformWidthPickup : PickUp
    {
        [SerializeField] private float _scale = 1;
    
        protected override void PerformActions()
        {
            base.PerformActions();

            Platform platform = FindObjectOfType<Platform>();
            platform.ChangePlatformWidthByScale(_scale);
        }
    }
    

}