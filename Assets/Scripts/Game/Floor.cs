using Arkanoid.Game.Services;
using Arkanoid.Utility;
using UnityEngine;

namespace Arkanoid.Game
{
    [RequireComponent(typeof(Collider2D))]
    public class Floor : SingletonMonoBehaviour<Floor>
    {
        #region Unity lifecycle

        private void Awake()
        {
            GetComponent<Collider2D>().isTrigger = true;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag(Tags.Ball))
            {
                GameService.Instance.BallHitFloor();
            }
            else
            {
                Destroy(other.gameObject);
            }
        }

        #endregion
    }
}