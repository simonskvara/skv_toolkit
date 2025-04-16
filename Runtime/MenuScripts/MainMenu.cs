using UnityEngine;
using UnityEngine.SceneManagement;

namespace skv_toolkit.MenuScripts
{
    public class MainMenu : MonoBehaviour
    {
        public void LoadScene(string sceneName)
        {
            Time.timeScale = 1f;
            PauseMenu.Instance.Resume();
            SceneLoader.LoadScene(sceneName);
        }

        public void ReloadScene()
        {
            Time.timeScale = 1f;
            SceneLoader.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}
