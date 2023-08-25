using Arkanoid.Utility;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Arkanoid.Infrastructure
{
    public class SceneLoader : SingletonMonoBehaviour<SceneLoader>
    {
        #region Public methods

        public bool IsLastLevel()
        {
            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

            return SceneManager.sceneCountInBuildSettings == nextSceneIndex;
        }

        public void LoadNextScene()
        {
            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

            SceneManager.LoadScene(nextSceneIndex);
        }

        public void LoadZeroScene()
        {
            SceneManager.LoadScene(0);
        }

        #endregion
    }
}