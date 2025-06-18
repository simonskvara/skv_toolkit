using UnityEngine;
using System.IO;
using System;

namespace skv_toolkit
{
    public static class SaveSystem
    {
        // Save to PlayerPrefs
        public static void Save(string key, int value) => PlayerPrefs.SetInt(key, value);
        public static void Save(string key, float value) => PlayerPrefs.SetFloat(key, value);
        public static void Save(string key, string value) => PlayerPrefs.SetString(key, value);

        // Load from PlayerPrefs
        public static int LoadInt(string key) => PlayerPrefs.GetInt(key);
        public static float LoadFloat(string key) => PlayerPrefs.GetFloat(key);
        public static string LoadString(string key) => PlayerPrefs.GetString(key);

        /// <summary>
        /// Save to JSON file with a data format
        /// </summary>
        public static void SaveToJson<T>(string fileName, T data)
        {
            string path = Path.Combine(Application.persistentDataPath, fileName);
            string json = JsonUtility.ToJson(data, true);
            File.WriteAllText(path, json);
        }

        /// <summary>
        /// Load from JSON file
        /// </summary>
        public static T LoadFromJson<T>(string fileName) where T : new()
        {
            string path = Path.Combine(Application.persistentDataPath, fileName);
        
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                return JsonUtility.FromJson<T>(json);
            }

            Debug.LogWarning("Save file not found. Creating new data.");
            return new T();
        }

        // Utility methods
        public static bool PlayerPrefsKeyExists(string key) => PlayerPrefs.HasKey(key);
        public static bool JsonFileExists(string fileName) => File.Exists(Path.Combine(Application.persistentDataPath, fileName));
        public static void DeleteJsonFile(string fileName) => File.Delete(Path.Combine(Application.persistentDataPath, fileName));
    }
}
