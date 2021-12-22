using System;
using UnityEngine;

public class ScoreManager
{
    private static string scoreString = "HighScore";

    private ScoreManager()
    {

    }

    public static ScoreManager Instance { get; } = new ScoreManager();

    /// <summary>
    /// Saves highscore to playerprefs and returns true if previous score was beaten, otherwise false
    /// </summary>
    /// <param name="points"></param>
    /// <returns></returns>
    public bool SaveHighScore(int points)
    {
        int prevScore = GetHighScore();
        int newScore = points;
        if(newScore > prevScore)
        {
            PlayerPrefs.SetInt(scoreString, newScore);
            return true;
        } else { return false; }
    }

    public int GetHighScore()
    {
        if (PlayerPrefs.HasKey(scoreString))
            return PlayerPrefs.GetInt(scoreString);
        else
            return 0;
    }
}
