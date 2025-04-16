using UnityEngine;
using UnityEngine.SceneManagement;

namespace skv_toolkit
{
    public static class SceneLoader
    {
        public static string TargetScene { get; private set; }

        public static void LoadScene(string sceneName)
        {
            TargetScene = sceneName;
            SceneManager.LoadScene("LoadingScreen");
        }
    }
}
