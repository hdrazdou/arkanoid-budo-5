using Arkanoid.Game.Services;
using UnityEngine;

namespace Arkanoid.Game.PickUps
{
    public class ChangeHpPickup : PickUp
    {
        [SerializeField] private int _hpToChange;

        protected override void PerformActions()
        {
            base.PerformActions();

            GameService.Instance.ChangeHp(_hpToChange);
        }
    }
}