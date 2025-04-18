using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace skv_toolkit.MenuScripts
{
    public class PauseMenu : MonoBehaviour
    {
        [Tooltip("Turn on when you need to unlock the cursor when pause menu is active")]
        public bool lockCursor;
        
        public static PauseMenu Instance;

        public static bool GameIsPaused;

        public GameObject pauseMenu;

        [SerializeField] private GameObject eventSystemObject;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }

            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void Start()
        {
            pauseMenu.SetActive(false);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (SceneManager.GetActiveScene().name != "MainMenu")
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
        }

        public void Resume()
        {
            Time.timeScale = 1f;
            pauseMenu.SetActive(false);
            GameIsPaused = false;

            if (lockCursor)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }

        void Pause()
        {
            pauseMenu.SetActive(true);
        
            Time.timeScale = 0f;
            GameIsPaused = true;

            if (lockCursor)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }

        public void RestartScene()
        {
            Resume();
            SceneLoader.LoadScene(SceneManager.GetActiveScene().name);
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            bool sceneHasEventSystem = false;
            foreach (var es in FindObjectsByType<EventSystem>(FindObjectsSortMode.None))
            {
                if (es.gameObject.scene == scene)
                {
                    sceneHasEventSystem = true;
                    break;
                }
            }
        
            eventSystemObject.SetActive(!sceneHasEventSystem);

            if (scene.name == "MainMenu")
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }

        private void OnDestroy()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }
}
