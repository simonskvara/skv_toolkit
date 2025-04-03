using UnityEngine;
using UnityEngine.SceneManagement;

namespace skv_toolkit.MenuScripts
{
    public class MainMenu : MonoBehaviour
    {
        public void LoadScene(string sceneName)
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(sceneName);
        }

        public void ReloadScene()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}
