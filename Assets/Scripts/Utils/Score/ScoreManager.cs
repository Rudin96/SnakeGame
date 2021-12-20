using UnityEngine;

public static class ScoreManager
{
    /// <summary>
    /// Saves highscore to playerprefs and returns true if previous score was beaten, otherwise false
    /// </summary>
    /// <param name="points"></param>
    /// <returns></returns>
    public static bool SaveHighScore(int points)
    {
        int prevScore = PlayerPrefs.GetInt("HighScore");
        int newScore = points;
        PlayerPrefs.SetInt("HighScore", newScore);
        return newScore > prevScore;
    }
}
