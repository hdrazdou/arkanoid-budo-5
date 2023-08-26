using Arkanoid.Utility;
using UnityEngine;

namespace Arkanoid.Game.Services
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioService : SingletonMonoBehaviour<AudioService>
    {
        #region Variables

        [SerializeField] private AudioSource _audioSource;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        #endregion

        #region Public methods

        public void PlayPickupSound(AudioClip audioClip)
        {
            if (audioClip == null)
            {
                return;
            }

            _audioSource.PlayOneShot(audioClip);
        }
        
        public void PlayExplosionSound(AudioClip audioClip)
        {
            if (audioClip == null)
            {
                return;
            }

            _audioSource.PlayOneShot(audioClip);
        }

        #endregion
    }
}