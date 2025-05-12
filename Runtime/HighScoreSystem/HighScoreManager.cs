using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace skv_toolkit.HighScoreSystem
{
    public class HighScoreManager : MonoBehaviour
    {
        public static HighScoreManager Instance;

        [SerializeField] private HighScoreConfig config;
        
        private List<HighScoreEntry> _entries = new List<HighScoreEntry>();
        public static event Action OnHighScoresUpdated;

        private void Awake()
        {
            if (!config)
                Debug.LogError("High score manager is missing a config scriptable object");
            
            if (Instance == null)
            {
                Instance = this;
                LoadHighScore();
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
        
        // call this method to 
        public void AddEntry(string playerName, float score)
        {
            var entry = new HighScoreEntry(playerName, score);

            if (ShouldAddEntry(score))
            {
                _entries.Add(entry);
                SortEntries();
                TrimExcessEntries();
                SaveHighScore();
                OnHighScoresUpdated?.Invoke();
            }
        }
        
        public IReadOnlyList<HighScoreEntry> GetScores() => _entries.AsReadOnly();

        private bool ShouldAddEntry(float newScore)
        {
            if (_entries.Count < config.maxEntries) return true;
            
            return config.sortingOrder switch
            {
                ScoreOrder.Ascending => newScore < _entries.Last().score,
                ScoreOrder.Descending => newScore > _entries.Last().score,
                _ => false
            };
        }

        private void SortEntries()
        {
            _entries = config.sortingOrder switch
            {
                ScoreOrder.Ascending => _entries.OrderBy(e => e.score).ToList(),
                ScoreOrder.Descending => _entries.OrderByDescending(e => e.score).ToList(),
                _ => _entries
            };
        }
        
        private void TrimExcessEntries()
        {
            while (_entries.Count > config.maxEntries)
            {
                _entries.RemoveAt(_entries.Count - 1);
            }
        }
        
        public void ClearEntries()
        {
            _entries.Clear();
            SaveHighScore();
            OnHighScoresUpdated?.Invoke();
        }

        private void LoadHighScore()
        {
            string path = GetSavePath();
            if (!File.Exists(path)) return;

            try
            {
                string json = File.ReadAllText(path);
                SaveData data = JsonUtility.FromJson<SaveData>(json);
                _entries = data.entries;
                SortEntries();
                TrimExcessEntries();
            }
            catch (Exception e)
            {
                Debug.LogError($"Failed to load high scores: {e.Message}");
            }
        }
        
        private void SaveHighScore()
        {
            try
            {
                SaveData data = new SaveData {entries = _entries};
                string json = JsonUtility.ToJson(data, true);
                File.WriteAllText(GetSavePath(), json);
                Debug.Log("Saved");
            }
            catch (Exception e)
            {
                Debug.LogError($"Failed to save high scores: {e.Message}");
            }
        }
        
        private string GetSavePath()
        {
            return Path.Combine(Application.persistentDataPath, "highscores.json");
        }
        
        [Serializable]
        private class SaveData
        {
            public List<HighScoreEntry> entries;
        }
    }
}
