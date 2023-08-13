using Arkanoid.Game.Services;
using UnityEngine;

namespace Arkanoid.Game.PickUps
{
    public class ChangeScorePickup : PickUp
    {
        #region Variables

        [SerializeField] private int _scoreToChange;

        #endregion

        #region Protected methods

        protected override void PerformActions()
        {
            base.PerformActions();

            GameService.Instance.AddScore(_scoreToChange);
        }

        #endregion
    }
}