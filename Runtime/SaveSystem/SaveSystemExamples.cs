using UnityEngine;
using System;

namespace skv_toolkit
{
    public class SaveSystemExamples : MonoBehaviour
    {
        // JSON example
        
        private void SaveToJson()
        {
            GameData data = new GameData();
            data.playerName = "Player1";
            data.level = 5;
            data.position = transform.position;
            data.unlockedWeapons = new bool[] { true, false, true };
            
            SaveSystem.SaveToJson("savegame.json", data);
        }

        private void LoadFromJson()
        {
            GameData loadedData = SaveSystem.LoadFromJson<GameData>("savegame.json");
            Debug.Log($"Loaded {loadedData.playerName} at level {loadedData.level}");
        }
        
        // Player Prefs Example

        private void SavePlayerPref()
        {
            SaveSystem.Save("HighScore", 100);
        }

        private void LoadPlayerPref()
        {
            int score = SaveSystem.LoadInt("HighScore");
        }
    }
    
    [Serializable]
    public class GameData
    {
        public string playerName;
        public int level;
        public Vector3 position;
        public bool[] unlockedWeapons;
    }
}
