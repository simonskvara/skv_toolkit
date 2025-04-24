#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

[InitializeOnLoad]
public class ScenePreviewGenerator
{
    static ScenePreviewGenerator()
    {
        // Subscribe to the sceneSaved event
        EditorSceneManager.sceneSaved += OnSceneSaved;
    }

    private static void OnSceneSaved(Scene scene)
    {
        // Find the preview camera
        Camera previewCam = GameObject.FindWithTag("PreviewCamera")?.GetComponent<Camera>();
        if (previewCam == null)
        {
            return;
        }

        // Capture the preview
        Texture2D preview = CapturePreview(previewCam, 1920, 1080);
        SavePreviewAsAsset(preview, scene.name);
        Debug.Log("Preview saved: " + SceneManager.GetActiveScene().name);
    }

    private static Texture2D CapturePreview(Camera camera, int width, int height)
    {
        // Set up a temporary RenderTexture
        RenderTexture rt = new RenderTexture(width, height, 24);
        camera.targetTexture = rt;
        camera.Render();

        // Convert to Texture2D
        Texture2D tex = new Texture2D(width, height, TextureFormat.RGB24, false);
        RenderTexture.active = rt;
        tex.ReadPixels(new Rect(0, 0, width, height), 0, 0);
        tex.Apply();

        // Cleanup
        RenderTexture.active = null;
        camera.targetTexture = null;
        Object.DestroyImmediate(rt);

        return tex;
    }

    private static void SavePreviewAsAsset(Texture2D texture, string sceneName)
    {
        // Save as PNG in Assets/LevelPreviews
        byte[] bytes = texture.EncodeToPNG();
        string folderPath = "Assets/Resources/LevelPreviews";
        if (!AssetDatabase.IsValidFolder(folderPath))
            AssetDatabase.CreateFolder("Assets", "LevelPreviews");

        string path = $"{folderPath}/{sceneName}_Preview.png";
        System.IO.File.WriteAllBytes(path, bytes);
        AssetDatabase.ImportAsset(path);

        // Set texture settings (optional)
        TextureImporter importer = AssetImporter.GetAtPath(path) as TextureImporter;
        if (importer != null)
        {
            importer.textureType = TextureImporterType.Sprite;
            importer.SaveAndReimport();
        }
    }
}
#endif