using Arkanoid.Game.Services;
using UnityEngine;

namespace Arkanoid.Game.PickUps
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(AudioSource))]
    public class PickUp : MonoBehaviour
    {
        #region Variables

        [SerializeField] private AudioClip _audioClip;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private int _score;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
            _audioSource.clip = _audioClip;
        }

        private void OnDestroy() { }

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
            PlayPickupSound();
        }

        #endregion

        #region Private methods

        private void PlayPickupSound()
        {
            if (_audioClip == null || _audioSource == null)
            {
                return;
            }

            _audioSource.clip = _audioClip;
            _audioSource.Play();
            Debug.Log("_audioSource.Play()");
        }

        #endregion
    }
}