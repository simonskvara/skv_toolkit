using UnityEngine;

namespace MenuScripts
{
    public class PauseMenu : MonoBehaviour
    {
        public static bool GameIsPaused;

        public GameObject pauseMenu;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (GameIsPaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
        }

        public void Resume()
        {
            Time.timeScale = 1f;
            pauseMenu.SetActive(false);
            GameIsPaused = false;
        }

        void Pause()
        {
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);
            GameIsPaused = true;
        }
    
    }
}
