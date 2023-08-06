using UnityEngine.SceneManagement;

namespace Arkanoid
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

        #endregion
    }
}