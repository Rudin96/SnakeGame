using System;
using System.Threading.Tasks;
using UnityEngine;

public class ScoreManager
{
    private ScoreManager()
    {

    }

    private async Task<bool> isNewHighScore(int score) => score >= await GetHighScore();

    public static ScoreManager Instance { get; } = new ScoreManager();

    /// <summary>
    /// Saves highscore to playerprefs and returns true if previous score was beaten, otherwise false
    /// </summary>
    /// <param name="points"></param>
    /// <returns></returns>
    public async Task<bool> SaveHighScoreAsync(int points)
    {
        int newScore = points;
        if(await isNewHighScore(points))
        {
            await DataManager.Instance.PostScoreDataAsync(newScore);
            return true;
        } else { return false; }
    }

    public async Task<int> GetHighScore()
    {
        return await DataManager.Instance.GetScoreDataAsync();
    }
}
