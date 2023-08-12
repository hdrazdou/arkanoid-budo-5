using UnityEngine;

namespace Arkanoid.Game.PickUps
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(BoxCollider2D))]
    public class PickUp : MonoBehaviour
    {
        #region Unity lifecycle

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag(Tags.Block))
            {
                return;
            }
            
            Destroy(gameObject);
            
            if (other.gameObject.CompareTag(Tags.Platform))
            {
                PerformActions();
            }
        }

        #endregion

        #region Protected methods

        protected virtual void PerformActions()
        {
            
        }

        #endregion
    }
}