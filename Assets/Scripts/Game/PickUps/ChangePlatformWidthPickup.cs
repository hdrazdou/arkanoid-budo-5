using UnityEngine;

namespace Arkanoid.Game.PickUps
{
    public class ChangePlatformWidthPickup : PickUp
    {
        #region Variables

        [SerializeField] private float _scale = 1;

        #endregion

        #region Protected methods

        protected override void PerformActions()
        {
            base.PerformActions();

            Platform platform = FindObjectOfType<Platform>();
            platform.ChangePlatformWidthByScale(_scale);
        }

        #endregion
    }
}