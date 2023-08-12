using Arkanoid.Utility;
using UnityEngine.SceneManagement;

namespace Arkanoid.Infrastructure
{
    public class SceneLoader : SingletonMonoBehaviour<SceneLoader>
    {
        #region Public methods

        public void LoadNextScene()
        {
            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

            if (SceneManager.sceneCountInBuildSettings == nextSceneIndex)
            {
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