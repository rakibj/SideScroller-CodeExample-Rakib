using RakibUtils;
using UnityEngine;

namespace _Project.Scripts.Generic
{
    public static class ScoreManager
    {
        public static int GetHighScore(int currentScore)
        {
            if (currentScore > PlayerPrefsExtended.LoadOrCreateKeyInt("HighScore"))
            {
                PlayerPrefs.SetInt("HighScore", currentScore);    
                return currentScore;
            }   
            
            return PlayerPrefsExtended.LoadOrCreateKeyInt("HighScore");
        }
    }
}
