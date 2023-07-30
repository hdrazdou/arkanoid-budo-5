using UnityEngine;
using UnityEngine.SceneManagement;

namespace Arkanoid
{
    public class Floor : MonoBehaviour
    {
        #region Unity lifecycle

        private void OnCollisionEnter2D(Collision2D other)
        {
            ReloadScene();
        }

        #endregion

        #region Private methods

        private void ReloadScene()
        {
            string currentScene = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentScene);
        }

        #endregion
    }
}