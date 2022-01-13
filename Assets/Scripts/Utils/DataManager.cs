using System.Net.Http;
using UnityEngine;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;

public class DataManager
{
    private static readonly string uri = "https://localhost:7294";

    private DataManager()
    {

    }

    public static DataManager Instance { get; } = new DataManager();

    public async Task<int> GetScoreDataAsync()
    {
        try
        {
            var res = await GetHttpClient().GetAsync("/api/highscores/top");
            res.EnsureSuccessStatusCode();
            string data = await res.Content.ReadAsStringAsync();
            return Convert.ToInt32(data);
        }
        catch (Exception e)
        {
            Debug.LogException(e);
            return -1;
        }
    }

    private HttpClient GetHttpClient()
    {
        HttpClient httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri(uri);
        return httpClient;
    }

    public async Task PostScoreDataAsync(int score)
    {
        HighScore highScore = new HighScore();
        highScore.Score = score;
        highScore.GameName = Application.productName;
        highScore.GameId = Guid.NewGuid();

        string stringContent = JsonConvert.SerializeObject(highScore);

        try
        {
            var res = await GetHttpClient().PostAsync("/api/highscores", new StringContent(stringContent, Encoding.UTF8, "application/json"));
            res.EnsureSuccessStatusCode();
        }
        catch (Exception e)
        {
            Debug.LogWarning(e.Message);
        }
    }
}
