using UnityEngine;
using System;

namespace skv_toolkit.HighScoreSystem
{
    [Serializable]
    public struct HighScoreEntry
    {
        public string playerName;
        public float score;
        
        public HighScoreEntry(string name, float score)
        {
            this.playerName = name;
            this.score = score;
        }
    }
    
    [CreateAssetMenu(menuName = "Systems/Highscores/Configuration")]
    public class HighScoreConfig : ScriptableObject
    {
        [Range(5, 50)] public int maxEntries = 10;
        public bool allowDuplicateNames = false;
        [Tooltip("Ascending is smaller to largest, eg. speedrun time \nDescending is largest to smallest, eg. enemies killed")]
        public ScoreOrder sortingOrder = ScoreOrder.Descending;
    }
    
    public enum ScoreOrder { Ascending, Descending }
}
