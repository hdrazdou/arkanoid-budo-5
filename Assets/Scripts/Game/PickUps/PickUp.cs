using Arkanoid.Game.Services;
using UnityEngine;

namespace Arkanoid.Game.PickUps
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(BoxCollider2D))]
    public class PickUp : MonoBehaviour
    {
        #region Variables

        [SerializeField] private AudioClip _audioClip;
        [SerializeField] private int _score;

        #endregion

        #region Unity lifecycle

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag(Tags.Platform))
            {
                PerformActions();
                Destroy(gameObject);
                GameService.Instance.ChangeScore(_score);
            }
        }

        #endregion

        #region Protected methods

        protected virtual void PerformActions()
        {
            AudioService.Instance.PlayPickupSound(_audioClip);
        }

        #endregion
    }
}