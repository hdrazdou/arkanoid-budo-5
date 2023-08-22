using Arkanoid.Game.Services;
using UnityEngine;

namespace Arkanoid.Game.PickUps
{
    public class ChangeHpPickup : PickUp
    {
        #region Variables

        [SerializeField] private int _hpToChange;

        #endregion

        #region Protected methods

        protected override void PerformActions()
        {
            base.PerformActions();

            GameService.Instance.ChangeHp(_hpToChange);
        }

        #endregion
    }
}