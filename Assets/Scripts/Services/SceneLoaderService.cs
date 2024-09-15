using UnityEngine.SceneManagement;

namespace Arkanoid.Services
{
    public class SceneLoaderService : SingletonMonoBehaviour<SceneLoaderService>
    {
        #region Public methods

        public static void LoadNextLevelTest()
        {
            //TODO: Sasha remove it
            SceneManager.LoadScene("GameScene_2");
        }

        public void ReloadCurrentScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        #endregion
    }
}