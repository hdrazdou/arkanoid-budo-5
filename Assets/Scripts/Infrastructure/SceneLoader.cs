using System;
using Arkanoid.Utility;
using UnityEngine.SceneManagement;

namespace Arkanoid.Infrastructure
{
    public class SceneLoader : SingletonMonoBehaviour<SceneLoader>
    {
        #region Events

        public event Action OnGameWon;

        #endregion

        #region Public methods

        public void LoadNextScene()
        {
            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

            if (SceneManager.sceneCountInBuildSettings == nextSceneIndex)
            {
                OnGameWon?.Invoke();
                return;
            }

            SceneManager.LoadScene(nextSceneIndex);
        }

        public void LoadZeroScene()
        {
            SceneManager.LoadScene(0);
        }

        #endregion
    }
}