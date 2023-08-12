using UnityEngine;

namespace Arkanoid.Game.PickUps
{
    public class DummyPickup : PickUp
    {
        #region Protected methods

        protected override void PerformActions()
        {
            base.PerformActions();
            
            Debug.Log("DummyPickup PerformActions");
        }

        #endregion
    }
}